using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace Mafia
{
    public class MafiaLoader
    {
        private static MafiaLoader defaultLoader;

        private string resourceName;

        static MafiaLoader()
        {
            defaultLoader = new MafiaLoader(Mafia.RESOURCE_NAME);
        }

        public MafiaLoader(string resourceName)
        {
            this.resourceName = resourceName;
        }

        public static MafiaLoader DefaultLoader
        {
            get
            {
                return defaultLoader;
            }
        }

        public FileStream GetFileStream(string fileName)
        {
            if (fileName.IndexOf(':') != -1)
            {
                return new FileStream(fileName, FileMode.Open);
            }

            var path = Path.Combine(GetExeDirectory(), resourceName, fileName);
            return new FileStream(path, FileMode.Open);
        }

        public Texture2D GetTexture(GraphicsDevice device, string fileName)
        {
            var path = Path.Combine(GetExeDirectory(), resourceName, fileName);
            return Texture2D.FromFile(device, path);
        }

        public SoundEffect GetBuffer(string fileName)
        {
            var path = Path.Combine(GetExeDirectory(), resourceName, fileName);
            return SoundEffect.FromStream(GetFileStream(path));
        }

        public Stage GetStage(string fileName)
        {
            using (Stream stream = GetFileStream(fileName))
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                string title = null;
                int numRows = 0;
                int numCols = 0;

                try
                {
                    title = reader.ReadLine();
                    numRows = int.Parse(reader.ReadLine());
                    numCols = int.Parse(reader.ReadLine());
                }
                catch (FormatException)
                {
                    throw new Exception("Faild to parse the stage file: " + fileName);
                }
                catch (OverflowException)
                {
                    throw new Exception("The stage is too large: " + fileName);
                }

                string[] source = new string[numRows];
                for (int row = 0; row < numRows; row++)
                {
                    source[row] = reader.ReadLine();
                }

                return new Stage(fileName, title, numRows, numCols, source);
            }
        }

        private static string GetExeDirectory()
        {
            return Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
        }
    }
}
