using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Syscrack
{

    public class AsciiViewport : Viewport
    {

        char[][] buffer;
        public Ascii Renderer;

        public AsciiViewport(int width, int height)
        {

            buffer = new char[height][];
            for (int i = 0; i < height; i++)
            {
                buffer[i] = new char[width];
            }

            this.Reset(); // puts the background char
            Renderer = new Ascii(this);
        }

        public override void Draw()
        {

            Console.Clear();

            for (int i = 0; i < buffer.Length; i++)
            {
                Console.Write(buffer[i]);
                Console.WriteLine();
            }

            this.Reset();
        }

        // Always remove base.Init()
        public override void Init()
        {


        }

        public void Set(int x, int y, char[] chars)
        {


            if (x < 0 || y < 0 || x > buffer[0].Length || y > buffer.Length)
                return;

            for (int i = 0; i < chars.Length; i++)
            {

                if (x + i < buffer[0].Length)
                {
                    buffer[y][x + i] = chars[i];
                }
            }
        }

        public void Remove(int x, int y, int length)
        {

            if (x < 0 || y < 0 || x > buffer[0].Length || y > buffer.Length)
                return;

            for (int i = 0; i < length; i++)
            {

                if (x + i < buffer[0].Length)
                {
                    buffer[y][x + i] = char.MinValue;
                }
            }
        }

        public void Reset()
        {

            var width = buffer[0].Length;
            var height = buffer.Length;

            buffer = new char[height][];
            for (int i = 0; i < height; i++)
            {
                buffer[i] = new char[width];

                //default background character
                for (int j = 0; j < width; j++)
                    buffer[i][j] = '_';
            }
        }
    }


    // :)
    public class Ascii
    {

        public AsciiViewport Viewport { get; set; }

        public Ascii(AsciiViewport viewport)
        {
            Viewport = viewport;
        }

        public void DrawRectangle(int x, int y, int width, int height, char background = '#')
        {

            for (int i = 0; i < height; i++)
            {

                var chars = new char[width];
                for (int j = 0; j < width; j++)
                    chars[j] = background;

                Viewport.Set(x, y + i, chars);
            }
        }

        public void DrawString(int x, int y, string str)
        {
            Viewport.Set(x, y, str.ToCharArray());
        }
    }
}
