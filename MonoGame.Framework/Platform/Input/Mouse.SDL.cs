﻿// MonoGame - Copyright (C) MonoGame Foundation, Inc
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using System;

namespace Microsoft.Xna.Framework.Input
{
    public static partial class Mouse
    {
        internal static int ScrollX;
        internal static int ScrollY;

        private static IntPtr PlatformGetWindowHandle()
        {
            return PrimaryWindow.Handle;
        }
        
        private static void PlatformSetWindowHandle(IntPtr windowHandle)
        {
        }

        private static MouseState PlatformGetState(GameWindow window)
        {
            int x, y;
            var winFlags = Sdl.Window.GetWindowFlags(window.Handle);
            var state = Sdl.Mouse.GetState(out x, out y);

            window.MouseState.LeftButton = (state & Sdl.Mouse.Button.Left) != 0 ? ButtonState.Pressed : ButtonState.Released;
            window.MouseState.MiddleButton = (state & Sdl.Mouse.Button.Middle) != 0 ? ButtonState.Pressed : ButtonState.Released;
            window.MouseState.RightButton = (state & Sdl.Mouse.Button.Right) != 0 ? ButtonState.Pressed : ButtonState.Released;
            window.MouseState.XButton1 = (state & Sdl.Mouse.Button.X1Mask) != 0 ? ButtonState.Pressed : ButtonState.Released;
            window.MouseState.XButton2 = (state & Sdl.Mouse.Button.X2Mask) != 0 ? ButtonState.Pressed : ButtonState.Released;

            window.MouseState.HorizontalScrollWheelValue = ScrollX;
            window.MouseState.ScrollWheelValue = ScrollY;

            window.MouseState.X = x;
            window.MouseState.Y = y;

            return window.MouseState;
        }

        private static void PlatformSetPosition(int x, int y)
        {
            PrimaryWindow.MouseState.X = x;
            PrimaryWindow.MouseState.Y = y;
            
            Sdl.Mouse.WarpInWindow(PrimaryWindow.Handle, x, y);
        }

        private static void PlatformSetCursor(MouseCursor cursor)
        {
            Sdl.Mouse.SetCursor(cursor.Handle);
        }
    }
}
