using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDBProject
{
    public enum SignType
    {
        Bes,
        Archival
    }

    public enum KDBOSaverType
    {
        DB,
        FTP
    }

    public enum KDBArchiveSaverType
    {
        DB,
        FTP
    }

    public enum Version
    {
        Version_2_0,
        Version_3_0
    }

    public class KDBConfiguration : IHasVersion
    {
        public int KDBTimeoutAsSeconds { get; set; }
        public SignType KDBOSignType { get; set; }
        public KDBOSaverType KDBOSaverType { get; set; }
        public KDBArchiveSaverType KDBArchiveSaverType { get; set; }
        public bool SaveKDBO { get; set; }
        public List<string> SerialNumbers { get; set; }
        public List<string> KdbNoList { get; set; }
        public List<string> VersionList { get; set; }
        public bool KdbArchivation { get; set; }
        public string DefaultVersion { get; set; }
    }
}
