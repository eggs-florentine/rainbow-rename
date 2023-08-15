using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace nl.florentine.processing
{
    public class FileManager
    {

        public FileManager() {
        public string testFCreated;
        public string testFPath;

        public string testDPath;
        public string testDCreated;
        }

        

        public dynamic processFile(string sourcePath, string destPath, string ext, bool testUse = false) {
            try
            {
                // INSTANCE: app data dir
                var adDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                Console.WriteLine("ad directory: " + adDirectory);
                // INSTANCE: app dir
                var directory = "";

                // CREATE: file for test purposes
                if (testUse && !testFCreated) {
                    File.Create(adDirectory + '\\' + "rmbwrnm.txt").Dispose();
                    testFCreated = true;
                }

                if (testUse && testFCreated) {
                    File.Create(adDirectory + '\\' + "rainbow-rename.txt").Dispose();
                    File.Delete(adDirectory + '\\' + "rmbwrnm.txt").Dispose();

                    if (!File.Exists(adDirectory + '\\' + "rmbwrnm.txt") && File.Exists(adDirectory + '\\' + "rainbow-rename.txt")) {
                        return true;
                    } else {
                        return false;
                    }
                }

                if (Directory.Exists(adDirectory))
                { 
                    directory = adDirectory + '\\' + "rainbowRename";
                    Console.WriteLine(directory);
                } else
                {
                    Directory.CreateDirectory(adDirectory + '\\' + "rainbowRename");
                    
                    if (Directory.Exists(adDirectory + '\\' + "rainbowRename"))
                    {
                        Console.WriteLine("cache directory exists");
                    }
                    directory = adDirectory + '\\' + "rainbowRename";
                    Console.WriteLine(directory);
                }
                    
                // CREATE: cache file
                File.Create(directory + '/' + "current" + ext).Dispose();
                Console.WriteLine("Beginning processing process..");
                // EDIT: cache file, file contents
                if (File.Exists(directory + '/' + "current" + ext))
                {
                    File.WriteAllText(directory + '/' + "current" + ext, File.ReadAllText(sourcePath));
                } else
                {
                    InternalException toThrow = new InternalException("The program aborted due to an issue in caching the current file. | InternalException FileManager.cs line 30");
                    return toThrow;
                }
                // DELETE: original file
                File.Delete(sourcePath);
                // CREATE: new file
                File.Create(destPath).Dispose();
                // EDIT: new file, cache file contents
                File.WriteAllText(destPath, File.ReadAllText(directory + '/' + "current" + ext));
                if (File.ReadAllText(directory + '/' + "current" + ext) == null)
                {
                    InternalException toThrow = new InternalException("The program aborted due to the cache file being null. | InternalException FileManager.cs line 41");
                }
                // DELETE: cache file
                File.Delete(directory + '/' + "current" + ext);
                // DELETE: original file
                if (File.Exists(destPath))
                {
                    File.Delete(sourcePath);
                }
                else {
                    InternalException toThrow = new InternalException("The program aborted due to the renaming process not working. | InternalException FileManager.cs line 51");
                }
                
            } catch (IOException) { 
                if (!File.Exists(sourcePath))
                } {
                    // CATCH: file provided does not exist
                    public FileNotFoundException toThrow = new FileNotFoundException("The program was unable to find any file meeting your requirements to rename. Have you chosen the right file extension?");
                    return toThrow;
                }
                return true;
            }
            
        }

        public static ArrayList indexFolder(string path, bool testUse = false) {
            ArrayList index = new ArrayList();

            foreach (string file in Directory.GetFiles(path)) {
                index.Add(file);
            }

            return index;
        }

        public static ArrayList queryIndex(ArrayList index, string query)
        {
            ArrayList result = new ArrayList();

            foreach (string item in index)
            {
                if (item.Contains(query))
                {
                    result.Add(item);
                }
            }

            return result;
        }
    }
}
