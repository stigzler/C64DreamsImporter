using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C64DreamsImporter.Services
{
    internal static class FileObjectTests
    {
        internal static bool IsLaunchboxRoot(string path)
        {
            if (!File.Exists(Path.Combine(path, "LaunchBox.exe")) || !Directory.Exists(Path.Combine(path, "Core"))) return false;
            return true;
        }

        internal static bool IsC64DreamsRoot(string path)
        {
            if (Path.GetFileName(path) != "C64 Dreams" || !Directory.Exists(Path.Combine(path, "C64 Dreams"))) return false;
            return true;
        }

        internal static bool IsHotfix0602(string path)
        {
            if (Path.GetFileName(path) != "C64 Dreams v0.60 Hotfix 6-5-2023") return false;
            return true;
        }
        internal static bool IsMagazineModule(string path)
        {
            if (Path.GetFileName(path) != "C64 Dreams - Magazine Module v0.60") return false;
            return true;
        }



    }
}
