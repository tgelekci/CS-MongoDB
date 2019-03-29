using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDBProject
{
    public interface IKDBConfigurationRepository
    {
       

        void Write(int KDBTimeoutAsSeconds, SignType KDBOSignType, KDBOSaverType KDBOSaverType, KDBArchiveSaverType KDBArchiveSaverType, bool SaveKDBO, List<string> SerialNumbers, List<string> KdbNoList, List<string> VersionList, bool KdbArchivation, string DefaultVersion);

    }
}
