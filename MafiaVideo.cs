
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mafia
{
    /// <summary>
    /// ��ʕ\���̉]�X�������B
    /// </summary>
    /// <remarks>
    /// �t���X�N���[������Alt+Tab�������Ă������B
    /// Sprite��DeviceLost����Dispose�����DeviceReset���ɃG���[����������B
    /// �ł��Đ������Ȃ��Ă������Ɠ����Ă���ۂ��̂ŕ��u�B
    /// </remarks>
    public class MafiaVideo : IDisposable
    {
        private MafiaApplication app;

        private SpriteBatch sprite;
        private Texture2D texture;

        public MafiaVideo(MafiaApplication app)
        {
            this.app = app;

            sprite = new SpriteBatch(app.Graphics.GraphicsDevice);
            texture = MafiaLoader.DefaultLoader.GetTexture(app.Graphics.GraphicsDevice, "mafia.bmp");
        }

        public void Begin()
        {
            sprite.Begin();
        }

        public void End()
        {
            sprite.End();
        }

        public void Present()
        {
        }

        public void Draw(int srcX, int srcY, int width, int height, int row, int col, int dstX, int dstY)
        {
            sprite.Draw(
                texture,
                new Rectangle(dstX, dstY, width, height),
                new Rectangle(srcX + width * col, srcY + height * row, width, height),
                Color.White);
        }

        public void DrawColor(int srcX, int srcY, int width, int height, int row, int col, int dstX, int dstY, Color color)
        {
            sprite.Draw(
                texture,
                new Rectangle(dstX, dstY, width, height),
                new Rectangle(srcX + width * col, srcY + height * row, width, height),
                color);
        }

        public void DrawString(string s, int x, int y, Color color)
        {
            for (int i = 0; i < s.Length; i++)
            {
                bool katakana = false;
                bool ten = false;
                bool maru = false;
                int row = 0;
                int col = 5;
                switch (s[i])
                {
                    case '��':
                        row = 0; col = 0; break;
                    case '��':
                        row = 0; col = 1; break;
                    case '��':
                        row = 0; col = 2; break;
                    case '��':
                        row = 0; col = 3; break;
                    case '��':
                        row = 0; col = 4; break;
                    case '��':
                        row = 1; col = 0; break;
                    case '��':
                        row = 1; col = 1; break;
                    case '��':
                        row = 1; col = 2; break;
                    case '��':
                        row = 1; col = 3; break;
                    case '��':
                        row = 1; col = 4; break;
                    case '��':
                        ten = true; row = 1; col = 0; break;
                    case '��':
                        ten = true; row = 1; col = 1; break;
                    case '��':
                        ten = true; row = 1; col = 2; break;
                    case '��':
                        ten = true; row = 1; col = 3; break;
                    case '��':
                        ten = true; row = 1; col = 4; break;
                    case '��':
                        row = 2; col = 0; break;
                    case '��':
                        row = 2; col = 1; break;
                    case '��':
                        row = 2; col = 2; break;
                    case '��':
                        row = 2; col = 3; break;
                    case '��':
                        row = 2; col = 4; break;
                    case '��':
                        ten = true; row = 2; col = 0; break;
                    case '��':
                        ten = true; row = 2; col = 1; break;
                    case '��':
                        ten = true; row = 2; col = 2; break;
                    case '��':
                        ten = true; row = 2; col = 3; break;
                    case '��':
                        ten = true; row = 2; col = 4; break;
                    case '��':
                        row = 3; col = 0; break;
                    case '��':
                        row = 3; col = 1; break;
                    case '��':
                        row = 3; col = 2; break;
                    case '��':
                        row = 11; col = 2; break;
                    case '��':
                        row = 3; col = 3; break;
                    case '��':
                        row = 3; col = 4; break;
                    case '��':
                        ten = true; row = 3; col = 0; break;
                    case '��':
                        ten = true; row = 3; col = 1; break;
                    case '��':
                        ten = true; row = 3; col = 2; break;
                    case '��':
                        ten = true; row = 3; col = 3; break;
                    case '��':
                        ten = true; row = 3; col = 4; break;
                    case '��':
                        row = 4; col = 0; break;
                    case '��':
                        row = 4; col = 1; break;
                    case '��':
                        row = 4; col = 2; break;
                    case '��':
                        row = 4; col = 3; break;
                    case '��':
                        row = 4; col = 4; break;
                    case '��':
                        row = 5; col = 0; break;
                    case '��':
                        row = 5; col = 1; break;
                    case '��':
                        row = 5; col = 2; break;
                    case '��':
                        row = 5; col = 3; break;
                    case '��':
                        row = 5; col = 4; break;
                    case '��':
                        ten = true; row = 5; col = 0; break;
                    case '��':
                        ten = true; row = 5; col = 1; break;
                    case '��':
                        ten = true; row = 5; col = 2; break;
                    case '��':
                        ten = true; row = 5; col = 3; break;
                    case '��':
                        ten = true; row = 5; col = 4; break;
                    case '��':
                        maru = true; row = 5; col = 0; break;
                    case '��':
                        maru = true; row = 5; col = 1; break;
                    case '��':
                        maru = true; row = 5; col = 2; break;
                    case '��':
                        maru = true; row = 5; col = 3; break;
                    case '��':
                        maru = true; row = 5; col = 4; break;
                    case '��':
                        row = 6; col = 0; break;
                    case '��':
                        row = 6; col = 1; break;
                    case '��':
                        row = 6; col = 2; break;
                    case '��':
                        row = 6; col = 3; break;
                    case '��':
                        row = 6; col = 4; break;
                    case '��':
                        row = 7; col = 0; break;
                    case '��':
                        row = 7; col = 2; break;
                    case '��':
                        row = 7; col = 4; break;
                    case '��':
                        row = 12; col = 0; break;
                    case '��':
                        row = 12; col = 2; break;
                    case '��':
                        row = 12; col = 4; break;
                    case '��':
                        row = 8; col = 0; break;
                    case '��':
                        row = 8; col = 1; break;
                    case '��':
                        row = 8; col = 2; break;
                    case '��':
                        row = 8; col = 3; break;
                    case '��':
                        row = 8; col = 4; break;
                    case '��':
                        row = 9; col = 0; break;
                    case '��':
                        row = 9; col = 4; break;
                    case '��':
                        row = 10; col = 0; break;
                    case '�A':
                        katakana = true; row = 0; col = 0; break;
                    case '�C':
                        katakana = true; row = 0; col = 1; break;
                    case '�E':
                        katakana = true; row = 0; col = 2; break;
                    case '�G':
                        katakana = true; row = 0; col = 3; break;
                    case '�I':
                        katakana = true; row = 0; col = 4; break;
                    case '�J':
                        katakana = true; row = 1; col = 0; break;
                    case '�L':
                        katakana = true; row = 1; col = 1; break;
                    case '�N':
                        katakana = true; row = 1; col = 2; break;
                    case '�P':
                        katakana = true; row = 1; col = 3; break;
                    case '�R':
                        katakana = true; row = 1; col = 4; break;
                    case '�K':
                        katakana = true; ten = true; row = 1; col = 0; break;
                    case '�M':
                        katakana = true; ten = true; row = 1; col = 1; break;
                    case '�O':
                        katakana = true; ten = true; row = 1; col = 2; break;
                    case '�Q':
                        katakana = true; ten = true; row = 1; col = 3; break;
                    case '�S':
                        katakana = true; ten = true; row = 1; col = 4; break;
                    case '�T':
                        katakana = true; row = 2; col = 0; break;
                    case '�V':
                        katakana = true; row = 2; col = 1; break;
                    case '�X':
                        katakana = true; row = 2; col = 2; break;
                    case '�Z':
                        katakana = true; row = 2; col = 3; break;
                    case '�\':
                        katakana = true; row = 2; col = 4; break;
                    case '�U':
                        katakana = true; ten = true; row = 2; col = 0; break;
                    case '�W':
                        katakana = true; ten = true; row = 2; col = 1; break;
                    case '�Y':
                        katakana = true; ten = true; row = 2; col = 2; break;
                    case '�[':
                        katakana = true; ten = true; row = 2; col = 3; break;
                    case '�]':
                        katakana = true; ten = true; row = 2; col = 4; break;
                    case '�^':
                        katakana = true; row = 3; col = 0; break;
                    case '�`':
                        katakana = true; row = 3; col = 1; break;
                    case '�c':
                        katakana = true; row = 3; col = 2; break;
                    case '�b':
                        katakana = true; row = 11; col = 2; break;
                    case '�e':
                        katakana = true; row = 3; col = 3; break;
                    case '�g':
                        katakana = true; row = 3; col = 4; break;
                    case '�_':
                        katakana = true; ten = true; row = 3; col = 0; break;
                    case '�a':
                        katakana = true; ten = true; row = 3; col = 1; break;
                    case '�d':
                        katakana = true; ten = true; row = 3; col = 2; break;
                    case '�f':
                        katakana = true; ten = true; row = 3; col = 3; break;
                    case '�h':
                        katakana = true; ten = true; row = 3; col = 4; break;
                    case '�i':
                        katakana = true; row = 4; col = 0; break;
                    case '�j':
                        katakana = true; row = 4; col = 1; break;
                    case '�k':
                        katakana = true; row = 4; col = 2; break;
                    case '�l':
                        katakana = true; row = 4; col = 3; break;
                    case '�m':
                        katakana = true; row = 4; col = 4; break;
                    case '�n':
                        katakana = true; row = 5; col = 0; break;
                    case '�q':
                        katakana = true; row = 5; col = 1; break;
                    case '�t':
                        katakana = true; row = 5; col = 2; break;
                    case '�w':
                        katakana = true; row = 5; col = 3; break;
                    case '�z':
                        katakana = true; row = 5; col = 4; break;
                    case '�o':
                        katakana = true; ten = true; row = 5; col = 0; break;
                    case '�r':
                        katakana = true; ten = true; row = 5; col = 1; break;
                    case '�u':
                        katakana = true; ten = true; row = 5; col = 2; break;
                    case '�x':
                        katakana = true; ten = true; row = 5; col = 3; break;
                    case '�{':
                        katakana = true; ten = true; row = 5; col = 4; break;
                    case '�p':
                        katakana = true; maru = true; row = 5; col = 0; break;
                    case '�s':
                        katakana = true; maru = true; row = 5; col = 1; break;
                    case '�v':
                        katakana = true; maru = true; row = 5; col = 2; break;
                    case '�y':
                        katakana = true; maru = true; row = 5; col = 3; break;
                    case '�|':
                        katakana = true; maru = true; row = 5; col = 4; break;
                    case '�}':
                        katakana = true; row = 6; col = 0; break;
                    case '�~':
                        katakana = true; row = 6; col = 1; break;
                    case '��':
                        katakana = true; row = 6; col = 2; break;
                    case '��':
                        katakana = true; row = 6; col = 3; break;
                    case '��':
                        katakana = true; row = 6; col = 4; break;
                    case '��':
                        katakana = true; row = 7; col = 0; break;
                    case '��':
                        katakana = true; row = 7; col = 2; break;
                    case '��':
                        katakana = true; row = 7; col = 4; break;
                    case '��':
                        katakana = true; row = 12; col = 0; break;
                    case '��':
                        katakana = true; row = 12; col = 2; break;
                    case '��':
                        katakana = true; row = 12; col = 4; break;
                    case '��':
                        katakana = true; row = 8; col = 0; break;
                    case '��':
                        katakana = true; row = 8; col = 1; break;
                    case '��':
                        katakana = true; row = 8; col = 2; break;
                    case '��':
                        katakana = true; row = 8; col = 3; break;
                    case '��':
                        katakana = true; row = 8; col = 4; break;
                    case '��':
                        katakana = true; row = 9; col = 0; break;
                    case '��':
                        katakana = true; row = 9; col = 4; break;
                    case '��':
                        katakana = true; row = 10; col = 0; break;
                    case '�[':
                        row = 10; col = 2; break;
                }
                if (ten)
                {
                    DrawColor(0, 176, 8, 8, 10, 3, x + i * 8, y - 8, color);
                }
                else if (maru)
                {
                    DrawColor(0, 176, 8, 8, 10, 4, x + i * 8, y - 8, color);
                }
                if (!katakana)
                {
                    DrawColor(0, 176, 8, 8, row, col, x + i * 8, y, color);
                }
                else
                {
                    DrawColor(64, 176, 8, 8, row, col, x + i * 8, y, color);
                }
            }
        }

        public void DrawStringCenter(string s, int offsetX, int offsetY, Color color)
        {
            DrawString(s, Mafia.SCREEN_WIDTH / 2 - s.Length * 4 + offsetX, Mafia.SCREEN_HEIGHT / 2 - 4 + offsetY, color);
        }

        public void FillScreen(Color color)
        {
            sprite.Draw(
                texture,
                new Rectangle(0, 0, Mafia.SCREEN_WIDTH, Mafia.SCREEN_HEIGHT),
                new Rectangle(0, 0, 16, 16),
                color);
        }

        public void DrawTitleScene(TitleScene title)
        {
            title.Draw(this);
        }

        public void DrawSelectScene(SelectScene select)
        {
            select.Draw(this);
        }

        public void DrawGameScene(GameScene game)
        {
            game.Draw(this);
        }

        public void DrawFps(int fps)
        {
            if (fps < 0) return;
            Point p = new Point(Mafia.SCREEN_WIDTH - 16, Mafia.SCREEN_HEIGHT - 16);
            int number = fps;
            int digit = 0;
            do
            {
                // Draw(textures.Number[number % 10], p - new Size(digit * 16, 0));
                number /= 10;
                digit++;
            }
            while (number > 0);
        }

        public void Dispose()
        {
            if (texture != null)
            {
                texture.Dispose();
                texture = null;
            }

            if (sprite != null)
            {
                sprite.Dispose();
                sprite = null;
            }
        }
    }
}
