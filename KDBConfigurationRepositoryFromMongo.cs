using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace KDBProject
{
    public class KDBConfigurationRepositoryFromMongo : IKDBConfigurationRepository
    {

 

        public KDBConfigurationRepositoryFromMongo()
        {

        }

       
        public void Write(int KDBTimeoutAsSeconds, SignType KDBOSignType, KDBOSaverType KDBOSaverType, KDBArchiveSaverType KDBArchiveSaverType, bool SaveKDBO, List<string> SerialNumbers, List<string> KdbNoList, List<string> VersionList, bool KdbArchivation, string DefaultVersion)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("kdbconfiguration");
            var collection = database.GetCollection<BsonDocument>("kdbcollection");

            var array = new BsonArray();
            foreach(var item in SerialNumbers)
            {
                array.Add(item);
            }

            var array2 = new BsonArray();
            foreach(var item2 in KdbNoList)
            {
                array2.Add(item2);
            }

            var array3 = new BsonArray();
            foreach(var item3 in VersionList)
            {
                array3.Add(item3);
            }

            
            var document = new BsonDocument
            {
                {"KDBTimeoutAsSeconds", KDBTimeoutAsSeconds},
                {"KDBOSignType", KDBOSignType},
                {"KDBOSaverType", KDBOSaverType},
                {"KDBArchiveSaverType", KDBArchiveSaverType},
                {"SaveKDBO", SaveKDBO },
                { "SerialNumbers", array },
                {"KdbNoList", array2 },
                {"VersionList", array3 },
                {"KdbArchivation", KdbArchivation},
                {"DefaultVersion", DefaultVersion}
            };

            collection.InsertOneAsync(document);
            Console.Read();
        }
    }
}
