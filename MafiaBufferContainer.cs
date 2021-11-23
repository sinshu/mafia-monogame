using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace Mafia
{
    public class MafiaBufferContainer
    {
        public SoundEffect Jump;
        public SoundEffect Tiun;
        public SoundEffect Coin;
        public SoundEffect Switch;
        public SoundEffect BoxMove;
        public SoundEffect BoxFall;
        public SoundEffect Lift;
        public SoundEffect Spring;
        public SoundEffect Fall;
        public SoundEffect Ue;
        public SoundEffect Hyakuyen;
        public SoundEffect Stiana;

        public MafiaBufferContainer(MafiaApplication app)
        {
            MafiaLoader loader = MafiaLoader.DefaultLoader;

            Jump = loader.GetBuffer("jump.wav");
            Tiun = loader.GetBuffer("tiun.wav");
            Coin = loader.GetBuffer("coin.wav");
            Switch = loader.GetBuffer("switch.wav");
            BoxMove = loader.GetBuffer("boxmove.wav");
            BoxFall = loader.GetBuffer("boxfall.wav");
            Lift = loader.GetBuffer("lift.wav");
            Spring = loader.GetBuffer("spring.wav");
            Fall = loader.GetBuffer("fall.wav");
            Ue = loader.GetBuffer("ue.wav");
            Hyakuyen = loader.GetBuffer("hyakuyen.wav");
            Stiana = loader.GetBuffer("stiana.wav");
        }

        public void Dispose()
        {
            if (Jump != null)
            {
                Jump.Dispose();
                Jump = null;
            }

            if (Tiun != null)
            {
                Tiun.Dispose();
                Tiun = null;
            }

            if (Coin != null)
            {
                Coin.Dispose();
                Coin = null;
            }

            if (Switch != null)
            {
                Switch.Dispose();
                Switch = null;
            }

            if (BoxMove != null)
            {
                BoxMove.Dispose();
                BoxMove = null;
            }

            if (BoxFall != null)
            {
                BoxFall.Dispose();
                BoxFall = null;
            }

            if (Lift != null)
            {
                Lift.Dispose();
                Lift = null;
            }

            if (Spring != null)
            {
                Spring.Dispose();
                Spring = null;
            }

            if (Fall != null)
            {
                Fall.Dispose();
                Fall = null;
            }

            if (Ue != null)
            {
                Ue.Dispose();
                Ue = null;
            }

            if (Hyakuyen != null)
            {
                Hyakuyen.Dispose();
                Hyakuyen = null;
            }

            if (Stiana != null)
            {
                Stiana.Dispose();
                Stiana = null;
            }
        }
    }
}
