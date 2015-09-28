using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Color = System.Drawing.Color;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Constants;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Rendering;
using EloBuddy.SDK.Utils;
using System.Globalization;
using System.Collections;

namespace silentClockBuddy
{
    class Program
    {
        public static Menu Menu;
        public static Menu settings;

        public static bool showclock
        {
            get { return settings.Get<CheckBox>("ShowClock").CurrentValue; }
        }

        public static bool typeclock
        {
            get { return settings.Get<CheckBox>("TypeClock").CurrentValue; }
        }

        public static bool showsecound
        {
            get { return settings.Get<CheckBox>("ShowSecound").CurrentValue; }
        }
        public static bool showtext
        {
            get { return settings.Get<CheckBox>("ShowText").CurrentValue; }
        }

        public static int positionX
        {
            get { return settings.Get<Slider>("X").CurrentValue; }
        }

        public static int positionY
        {
            get { return settings.Get<Slider>("Y").CurrentValue; }
        }

        public static int colorR
        {
            get { return settings.Get<Slider>("R").CurrentValue; }
        }

        public static int colorG
        {
            get { return settings.Get<Slider>("G").CurrentValue; }
        }

        public static int colorB
        {
            get { return settings.Get<Slider>("B").CurrentValue; }
        }


        private static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }

        private static void Loading_OnLoadingComplete(EventArgs args)
        {
            Menu = MainMenu.AddMenu("silentClock", "silent");
            settings = Menu.AddSubMenu("Settings", "Settings");

            Menu.AddLabel("silentClockBudyy v.1.0");
            Menu.AddSeparator();
            Menu.AddLabel("Report bugs or suggestions on the thread!");
            Menu.AddLabel("If you change resolution reload script!");
            Menu.AddSeparator();
            Menu.AddSeparator();
            Menu.AddSeparator();
            Menu.AddSeparator();
            Menu.AddSeparator();
            Menu.AddLabel("By silent");
            Menu.AddLabel("https://github.com/sileent/EloBuddy");
            
            Menu.AddSeparator();

            settings.AddLabel("General:");
            settings.Add("ShowClock", new CheckBox("Show Clock"));
            settings.Add("TypeClock", new CheckBox("Type: 24h / 12h"));
            settings.Add("ShowSecound", new CheckBox("Show Secound"));
            settings.Add("ShowText", new CheckBox("Show text ''Time Now:''"));
            settings.AddSeparator();
            settings.AddLabel("Position:");
            settings.Add<Slider>("X", new Slider("X", 0, 0, Drawing.Width));
            settings.Add<Slider>("Y", new Slider("Y", 0, 0, Drawing.Height));
            settings.AddSeparator();
            settings.AddLabel("Color:");
            settings.Add<Slider>("R", new Slider("R", 255, 0, 255));
            settings.Add<Slider>("G", new Slider("G", 0, 0, 255));
            settings.Add<Slider>("B", new Slider("B", 0, 0, 255));
            
            Drawing.OnDraw += Drawing_OnDraw;
            Chat.Print("silentClockBuddy Loaded! v. " + "1.0", Color.Red);


            Game.OnUpdate += Game_OnUpdate;
        }

        private static void Game_OnUpdate(EventArgs args)
        {


        }


        private static void Drawing_OnDraw(EventArgs args)
        {
            if (showclock)
            {

                if (showtext)
                {
                    if (showsecound)
                    {

                        if (typeclock)
                        {
                            string text = "Time Now: " + DateTime.Now.ToString("H:mm:ss", new CultureInfo("en-US"));
                            Drawing.DrawText(positionX, positionY, Color.FromArgb(colorR, colorG, colorB), text);
                        }
                        else
                        {
                            string text = "Time Now: " + DateTime.Now.ToString("h:mm:ss tt", new CultureInfo("en-US"));
                            Drawing.DrawText(positionX, positionY, Color.FromArgb(colorR, colorG, colorB), text);
                        }

                    }
                    else
                    {
                        if (typeclock)
                        {
                            string text = "Time Now: " + DateTime.Now.ToString("H:mm", new CultureInfo("en-US"));
                            Drawing.DrawText(positionX, positionY, Color.FromArgb(colorR, colorG, colorB), text);
                        }
                        else
                        {
                            string text = "Time Now: " + DateTime.Now.ToString("h:mm tt", new CultureInfo("en-US"));
                            Drawing.DrawText(positionX, positionY, Color.FromArgb(colorR, colorG, colorB), text);
                        }
                    }
                }
                else
                {
                    if (showsecound)
                    {

                        if (typeclock)
                        {
                            string text = DateTime.Now.ToString("H:mm:ss", new CultureInfo("en-US"));
                            Drawing.DrawText(positionX, positionY, Color.FromArgb(colorR, colorG, colorB), text);
                        }
                        else
                        {
                            string text = DateTime.Now.ToString("h:mm:ss tt", new CultureInfo("en-US"));
                            Drawing.DrawText(positionX, positionY, Color.FromArgb(colorR, colorG, colorB), text);
                        }

                    }
                    else
                    {
                        if (typeclock)
                        {
                            string text = DateTime.Now.ToString("H:mm", new CultureInfo("en-US"));
                            Drawing.DrawText(positionX, positionY, Color.FromArgb(colorR, colorG, colorB), text);
                        }
                        else
                        {
                            string text = DateTime.Now.ToString("h:mm tt", new CultureInfo("en-US"));
                            Drawing.DrawText(positionX, positionY, Color.FromArgb(colorR, colorG, colorB), text);
                        }
                    }
                }

            }

        }

    }
}
