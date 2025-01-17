﻿using LoESoft.Client.Core.Game.User.GUI.Icon;
using LoESoft.Client.Core.Game.User.GUI.UI;
using LoESoft.Client.Core.Game.User.GUI.UI.Elements.StatusBar;
using LoESoft.Client.Core.Networking;
using LoESoft.Client.Drawing;
using LoESoft.Client.Drawing.Sprites.Forms;
using Microsoft.Xna.Framework.Graphics;

namespace LoESoft.Client.Core.Game.User.GUI
{
    public class PlayerHUD : Mask
    {
        public IconTab Icons { get; private set; }

        public PlayerInfoTable InfoTable { get; private set; }
        public OptionsTable OptionTable { get; private set; }
        public MiniMap MiniMapView { get; private set; }

        public StatusBarView HealthBar { get; private set; }

        public PlayerHUD()
            : base(new RGBColor(0, 0, 0), 0f)
        {
            IsEventApplicable = false;

            Icons = new IconTab(975, 5, toggleInfoTable, toggleOptions, toggleMinimap);

            InfoTable = new PlayerInfoTable();
            OptionTable = new OptionsTable();
            MiniMapView = new MiniMap(950, 60);

            HealthBar = new StatusBarView(10, 10, 350, 40, "HP", new RGBColor(255, 12, 5));

            AddChild(Icons);
            AddChild(HealthBar);
        }

        public void DrawMinimap(SpriteBatch spriteBatch, int x, int y)
        {
            if (Icons.Contains(MiniMapView))
                MiniMapView.DrawMap(spriteBatch, x, y);
        }

        public void UpdateStatus(string name, int curHp, int maxHp)
        {
            if (!string.IsNullOrEmpty(name))
                InfoTable.Title.Text = name;

            HealthBar.UpdateStatus(maxHp, curHp);
            InfoTable.StatsView.UpdateStat(maxHp);
        }

        private void toggleOptions()
        {
            if (Icons.Contains(OptionTable))
                Icons.RemoveChild(OptionTable);
            else
                Icons.AddChild(OptionTable);
        }

        private void toggleMinimap()
        {
            if (Icons.Contains(MiniMapView))
                Icons.RemoveChild(MiniMapView);
            else
                Icons.AddChild(MiniMapView);
        }

        private void toggleInfoTable()
        {
            if (Icons.Contains(InfoTable))
                Icons.RemoveChild(InfoTable);
            else
                Icons.AddChild(InfoTable);
        }
    }
}