﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace PDS.Witsml.Server.Data
{
    /// <summary>
    /// MongoDb data adapter that encapsulates CRUD functionality for WITSML objects.
    /// </summary>
    /// <typeparam name="T">Type of the object</typeparam>
    /// <seealso cref="Data.WitsmlDataAdapter{T}" />
    public abstract class MongoDbDataAdapter<T> : WitsmlDataAdapter<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MongoDbDataAdapter{T}" /> class.
        /// </summary>
        /// <param name="databaseProvider">The database provider.</param>
        /// <param name="dbCollectionName">The database collection name.</param>
        /// <param name="idPropertyName">The name of the identifier property.</param>
        /// <param name="namePropertyName">The name of the object name property</param>
        public MongoDbDataAdapter(IDatabaseProvider databaseProvider, string dbCollectionName, string idPropertyName = ObjectTypes.Uid, string namePropertyName = ObjectTypes.NameProperty)
        {
            DatabaseProvider = databaseProvider;
            DbCollectionName = dbCollectionName;
            IdPropertyName = idPropertyName;
            NamePropertyName = namePropertyName;
        }

        /// <summary>
        /// Gets the database provider used for accessing MongoDb.
        /// </summary>
        /// <value>The database provider.</value>
        protected IDatabaseProvider DatabaseProvider { get; private set; }

        /// <summary>
        /// Gets the database collection name for the data object.
        /// </summary>
        /// <value>The database collection name.</value>
        protected string DbCollectionName { get; private set; }

        /// <summary>
        /// Gets the name of the identifier property.
        /// </summary>
        /// <value>The name of the identifier property.</value>
        protected string IdPropertyName { get; private set; }

        /// <summary>
        /// Gets the name of the Name property.
        /// </summary>
        /// <value>The name of the Name property.</value>
        protected string NamePropertyName { get; private set; }

        /// <summary>
        /// Gets a data object by the specified UUID.
        /// </summary>
        /// <param name="dataObjectId">The data object identifier.</param>
        /// <returns>The data object instance.</returns>
        public override T Get(DataObjectId dataObjectId)
        {
            return GetEntity(dataObjectId);
        }

        /// <summary>
        /// Deletes a data object by the specified UUID.
        /// </summary>
        /// <param name="uuid">The UUID.</param>
        /// <returns>A WITSML result.</returns>
        public override WitsmlResult Delete(string uuid)
        {
            return DeleteEntity(uuid);
        }

        /// <summary>
        /// Determines whether the entity exists in the data store.
        /// </summary>
        /// <param name="dataObjectId">The data object identifier.</param>
        /// <returns>true if the entity exists; otherwise, false</returns>
        public override bool Exists(DataObjectId dataObjectId)
        {
            return Exists<T>(dataObjectId, DbCollectionName);
        }

        /// <summary>
        /// Determines whether the entity exists in the data store.
        /// </summary>
        /// <param name="dataObjectId">The data object identifier.</param>
        /// <param name="dbCollectionName">The name of the database collection.</param>
        /// <typeparam name="TObject">The data object type.</typeparam>
        /// <returns>true if the entity exists; otherwise, false</returns>
        protected bool Exists<TObject>(DataObjectId dataObjectId, string dbCollectionName)
        {
            try
            {
                return GetEntityByUidQuery<TObject>(dataObjectId, dbCollectionName) != null;
            }
            catch (MongoException ex)
            {
                Logger.Error("Error querying " + dbCollectionName, ex);
                throw new WitsmlException(ErrorCodes.ErrorReadingFromDataStore, ex);
            }
        }

        protected IMongoCollection<T> GetCollection()
        {
            return GetCollection<T>(DbCollectionName);
        }

        protected IMongoCollection<TObject> GetCollection<TObject>(string dbCollectionName)
        {
            var database = DatabaseProvider.GetDatabase();
            return database.GetCollection<TObject>(dbCollectionName);
        }

        protected IMongoQueryable<T> GetQuery()
        {
            return GetQuery<T>(DbCollectionName);
        }

        protected IMongoQueryable<TObject> GetQuery<TObject>(string dbCollectionName)
        {
            return GetCollection<TObject>(dbCollectionName).AsQueryable();
        }

        /// <summary>
        /// Gets an object from the data store by uid
        /// </summary>
        /// <param name="dataObjectId">The data object identifier.</param>
        /// <returns>The object represented by the UID.</returns>
        protected T GetEntity(DataObjectId dataObjectId)
        {
            return GetEntity<T>(dataObjectId, DbCollectionName);
        }

        /// <summary>
        /// Gets an object from the data store by uid
        /// </summary>
        /// <param name="dataObjectId">The data object identifier.</param>
        /// <param name="dbCollectionName">The naame of the database collection.</param>
        /// <typeparam name="TObject">The data object type.</typeparam>
        /// <returns>The entity represented by the indentifier.</returns>
        protected TObject GetEntity<TObject>(DataObjectId dataObjectId, string dbCollectionName)
        {
            try
            {
                Logger.DebugFormat("Querying {0} MongoDb collection; uid: {1}", dbCollectionName, dataObjectId);
                return GetEntityByUidQuery<TObject>(dataObjectId, dbCollectionName);
            }
            catch (MongoException ex)
            {
                Logger.ErrorFormat("Error querying {0} MongoDb collection:{1}{2}", dbCollectionName, Environment.NewLine, ex);
                throw new WitsmlException(ErrorCodes.ErrorReadingFromDataStore, ex);
            }
        }

        /// <summary>
        /// Gets the entity by uid query.
        /// </summary>
        /// <param name="dataObjectId">The data object identifier.</param>
        /// <returns>The entity represented by the indentifier.</returns>
        protected T GetEntityByUidQuery(DataObjectId dataObjectId)
        {
            return GetEntityByUidQuery<T>(dataObjectId, DbCollectionName);
        }

        /// <summary>
        /// Gets the entity by uid query.
        /// </summary>
        /// <typeparam name="TObject">The type of the object.</typeparam>
        /// <param name="dataObjectId">The data object identifier.</param>
        /// <param name="dbCollectionName">Name of the database collection.</param>
        /// <returns></returns>
        protected TObject GetEntityByUidQuery<TObject>(DataObjectId dataObjectId, string dbCollectionName)
        {
            var filters = new List<FilterDefinition<TObject>>();

            filters.Add(Builders<TObject>.Filter.EqIgnoreCase(IdPropertyName, dataObjectId.Uid));

            if (dataObjectId is WellObjectId)
            {
                filters.Add(Builders<TObject>.Filter.EqIgnoreCase("UidWell", ((WellObjectId)dataObjectId).UidWell));
            }
            if (dataObjectId is WellboreObjectId)
            {
                filters.Add(Builders<TObject>.Filter.EqIgnoreCase("UidWellbore", ((WellboreObjectId)dataObjectId).UidWellbore));
            }

            var exclude = Builders<TObject>.Projection.Exclude("_id");

            return GetCollection<TObject>(dbCollectionName)
                .Find(Builders<TObject>.Filter.And(filters))
                .Project<TObject>(exclude)
                .FirstOrDefault();
        }

        /// <summary>
        /// Queries the data store with Mongo Bson filter and projection.
        /// </summary>
        /// <param name="parser">The parser.</param>
        /// <param name="tList">List of query for object T.</param>
        /// <returns>The query results collection.</returns>
        protected List<T> QueryEntities<TList>(WitsmlQueryParser parser, List<string> fields)
        {
            try
            {
                if (OptionsIn.RequestObjectSelectionCapability.True.Equals(parser.RequestObjectSelectionCapability()))
                {
                    Logger.DebugFormat("Requesting {0} query template.", DbCollectionName);
                    var queryTemplate = CreateQueryTemplate();
                    return queryTemplate.AsList();
                }

                Logger.DebugFormat("Querying {0} MongoDb collection.", DbCollectionName);
                var query = new MongoDbQuery<TList, T>(GetCollection(), parser, fields, IdPropertyName);
                return query.Execute();
            }
            catch (MongoException ex)
            {
                Logger.ErrorFormat("Error querying {0} MongoDb collection:{1}{2}", DbCollectionName, Environment.NewLine, ex);
                throw new WitsmlException(ErrorCodes.ErrorReadingFromDataStore, ex);
            }
        }

        /// <summary>
        /// Inserts an object into the data store.
        /// </summary>
        /// <param name="entity">The object to be inserted.</param>
        protected void InsertEntity(T entity)
        {
            InsertEntity(entity, DbCollectionName);
        }

        /// <summary>
        /// Inserts an object into the data store.
        /// </summary>
        /// <param name="entity">The object to be inserted.</param>
        /// <param name="dbCollectionName">The name of the database collection.</param>
        /// <typeparam name="TObject">The data object type.</typeparam>
        protected void InsertEntity<TObject>(TObject entity, string dbCollectionName)
        {
            try
            {
                Logger.DebugFormat("Inserting into {0} MongoDb collection.", dbCollectionName);

                var collection = GetCollection<TObject>(dbCollectionName);

                collection.InsertOne(entity);
            }
            catch (MongoException ex)
            {
                Logger.ErrorFormat("Error inserting into {0} MongoDb collection:{1}{2}", dbCollectionName, Environment.NewLine, ex);
                throw new WitsmlException(ErrorCodes.ErrorAddingToDataStore, ex);
            }
        }

        /// <summary>
        /// Initializes a new UID value if one was not supplied.
        /// </summary>
        /// <param name="uid">The supplied UID (default value null).</param>
        /// <returns>The supplied UID if not null; otherwise, a generated UID.</returns>
        protected string NewUid(string uid = null)
        {
            if (string.IsNullOrEmpty(uid))
            {
                uid = Guid.NewGuid().ToString();
            }

            return uid;
        }

        /// <summary>
        /// Deletes a data object by the specified UUID.
        /// </summary>
        /// <param name="uuid">The UUID.</param>
        /// <returns>A WITSML result.</returns>
        /// <exception cref="WitsmlException"></exception>
        protected WitsmlResult DeleteEntity(string uuid)
        {
            return DeleteEntity<T>(uuid, DbCollectionName);
        }

        /// <summary>
        /// Deletes a data object by the specified UUID.
        /// </summary>
        /// <typeparam name="TObject">The type of data object.</typeparam>
        /// <param name="uuid">The UUID.</param>
        /// <param name="dbCollectionName">The name of the database collection.</param>
        /// <returns>A WITSML result.</returns>
        /// <exception cref="WitsmlException"></exception>
        protected WitsmlResult DeleteEntity<TObject>(string uuid, string dbCollectionName)
        {
            try
            {
                Logger.DebugFormat("Deleting from {0} MongoDb collection", dbCollectionName);

                var collection = GetCollection<TObject>(dbCollectionName);
                var filter = Builders<TObject>.Filter.Eq(IdPropertyName, uuid);
                var result = collection.DeleteOne(filter);

                return new WitsmlResult(ErrorCodes.Success);
            }
            catch (MongoException ex)
            {
                Logger.ErrorFormat("Error deleting from {0} MongoDb collection:{1}{2}", dbCollectionName, Environment.NewLine, ex);
                throw new WitsmlException(ErrorCodes.ErrorDeletingFromDataStore, ex);
            }
        }
    }
}
