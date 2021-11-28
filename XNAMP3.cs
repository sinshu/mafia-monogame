// /***************************************************************************
//  * XNAMP3.cs
//  * Copyright (c) 2015 the authors.
//  * 
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) version 3 which accompanies this distribution, and is available at
//  * https://www.gnu.org/licenses/lgpl-3.0.en.html
//  *
//  * This library is distributed in the hope that it will be useful,
//  * but WITHOUT ANY WARRANTY; without even the implied warranty of
//  * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU
//  * Lesser General Public License for more details.
//  *
//  ***************************************************************************/

using System;
using System.IO;
using Microsoft.Xna.Framework.Audio;
using MP3Sharp;

namespace Mafia
{
    public class XNAMP3 : IDisposable
    {
        private readonly static int bufferSize = 4 * (44100 / 10);

        private MP3Stream stream;
        private DynamicSoundEffectInstance dynamicSound;

        private readonly byte[] buffer;

        private bool repeat;
        private bool playing;

        public XNAMP3(string path)
        {
            var ms = new MemoryStream(File.ReadAllBytes(path));

            stream = new MP3Stream(ms, bufferSize);
            dynamicSound = new DynamicSoundEffectInstance(stream.Frequency, AudioChannels.Stereo);
            dynamicSound.Volume = 0.9F;

            buffer = new byte[bufferSize];
        }

        public void Dispose()
        {
            if (playing)
            {
                Stop();
            }

            if (dynamicSound != null)
            {
                dynamicSound.Dispose();
                dynamicSound = null;
            }

            if (stream != null)
            {
                stream.Dispose();
                stream = null;
            }
        }

        public void Play(bool repeat = false)
        {
            if (playing)
            {
                Stop();
            }

            playing = true;
            this.repeat = repeat;

            stream.Position = 0;

            SubmitBuffer(3);
            dynamicSound.BufferNeeded += InstanceBufferNeeded;
            dynamicSound.Play();
        }

        public void Stop()
        {
            if (playing)
            {
                playing = false;
                dynamicSound.Stop();
                dynamicSound.BufferNeeded -= InstanceBufferNeeded;
            }
        }

        private void InstanceBufferNeeded(object sender, EventArgs e)
        {
            SubmitBuffer();
        }

        private void SubmitBuffer(int count = 1)
        {
            while (count > 0)
            {
                ReadFromStream();
                dynamicSound.SubmitBuffer(buffer);
                count--;
            }
        }

        private void ReadFromStream()
        {
            int bytesReturned = stream.Read(buffer, 0, buffer.Length);
            if (bytesReturned != bufferSize)
            {
                if (repeat)
                {
                    stream.Position = 0;
                    stream.Read(buffer, bytesReturned, buffer.Length - bytesReturned);
                }
                else
                {
                    if (bytesReturned == 0)
                    {
                        Stop();
                    }
                }
            }
        }

        public SoundState State => dynamicSound.State;
    }
}
