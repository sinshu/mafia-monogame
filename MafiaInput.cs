using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Mafia
{
    public class MafiaInput : IDisposable
    {
        private MafiaApplication app;

        private KeyboardState keyboardState;

        private bool left;
        private bool up;
        private bool right;
        private bool down;
        private bool space;
        private bool esc;

        private bool prevLeft;
        private bool prevUp;
        private bool prevRight;
        private bool prevDown;
        private bool prevSpace;
        private bool prevEsc;

        public MafiaInput(MafiaApplication app)
        {
            this.app = app;

            prevLeft = prevUp = prevRight = prevDown = false;
            prevSpace = false;
            prevEsc = false;
        }

        public TitleInput GetCurrentTitleInput()
        {
            UpdateKeys();

            return new TitleInput(up, down, space && !prevSpace, esc && !prevEsc);
        }

        public SelectInput GetCurrentSelectInput()
        {
            UpdateKeys();

            return new SelectInput(left && !prevLeft, up && !prevUp, right && !prevRight, down && !prevDown, space && !prevSpace, esc && !prevEsc);
        }

        public GameInput GetCurrentGameInput()
        {
            UpdateKeys();

            return new GameInput(left, up, right, down, space && !prevSpace, esc && !prevEsc);
        }

        public void Dispose()
        {
        }

        private void UpdateKeys()
        {
            keyboardState = Keyboard.GetState();

            prevLeft = left;
            prevUp = up;
            prevRight = right;
            prevDown = down;
            prevSpace = space;
            prevEsc = esc;

            left = keyboardState.IsKeyDown(Keys.Left);

            up = keyboardState.IsKeyDown(Keys.Up) ||
                 keyboardState.IsKeyDown(Keys.A) ||
                 keyboardState.IsKeyDown(Keys.S) ||
                 keyboardState.IsKeyDown(Keys.Z) ||
                 keyboardState.IsKeyDown(Keys.LeftShift) ||
                 keyboardState.IsKeyDown(Keys.LeftControl);

            right = keyboardState.IsKeyDown(Keys.Right);
            down = keyboardState.IsKeyDown(Keys.Down);

            space = keyboardState.IsKeyDown(Keys.Enter) || keyboardState.IsKeyDown(Keys.Space);
            esc = keyboardState.IsKeyDown(Keys.Escape);
        }
    }
}
