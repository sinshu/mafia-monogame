using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace Mafia
{
    public class MafiaSound : IDisposable
    {
        private MafiaApplication app;

        private MafiaBufferContainer buffers;

        public MafiaSound(MafiaApplication app)
        {
            this.app = app;

            buffers = new MafiaBufferContainer(app);
        }

        public void Play(SoundEffect buffer, Thing thing)
        {
            var sound = buffer.CreateInstance();
            sound.Pan = CalcPan(thing);
            if (thing is Lift)
            {
                sound.Volume = 0.25F * CalcVolume(thing);
            }
            else
            {
                sound.Volume = CalcVolume(thing);
            }
            sound.Play();
        }

        public void PlaySelectSound(SelectScene select)
        {
            select.PlaySound(this, buffers);
        }

        public void PlayGameSound(GameScene game)
        {
            game.ThingList.PlaySound(this, buffers);
        }

        public void StopSounds()
        {
        }

        private float CalcPan(Thing thing)
        {
            if (thing == null)
            {
                return 0;
            }

            double pan = (thing.CenterOnScreen.X - Mafia.SCREEN_WIDTH / 2) / (Mafia.SCREEN_WIDTH * 4);
            if (Math.Abs(pan) > 0.999)
            {
                pan = Math.Sign(pan) * 0.999;
            }

            return (float)pan;
        }

        private float CalcVolume(Thing thing)
        {
            if (thing == null)
            {
                return 1;
            }

            Vector v = thing.CenterOnScreen;
            if (0 < v.X && v.X < Mafia.SCREEN_WIDTH && 0 < v.Y && v.Y < Mafia.SCREEN_HEIGHT)
            {
                return 1;
            }

            double range1 = -v.X;
            double range2 = v.X - Mafia.SCREEN_WIDTH;
            double range3 = -v.Y;
            double range4 = v.Y - Mafia.SCREEN_HEIGHT;
            double range = Math.Max(Math.Max(range1, range2), Math.Max(range3, range4));

            double volume = 1.0 - (range / Mafia.SOUND_RANGE);
            if (volume < 0) volume = 0;
            if (volume > 1) volume = 1;

            return (float)volume;
        }

        public void Dispose()
        {
        }
    }
}
