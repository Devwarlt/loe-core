using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;

namespace LoESoft.Client.Assets
{
    public sealed class AudioManager
    {
        private static Dictionary<string, SoundEffect> SoundEffects { get; set; }
        private static Dictionary<string, Song> Music { get; set; }

        private static Song ActiveMusic { get; set; }

        public static bool IsSfxMuted { get; set; }
        public static bool IsMusicMuted { get; set; }

        public static void Init()
        {
            LoadSfxSound("error", "sfx/error");
            LoadMusic("titleScreenMusic", "music/titleScreen");
        }

        public static void LoadSfxSound(string sound, string path)
        {
            if (SoundEffects == null)
                SoundEffects = new Dictionary<string, SoundEffect>();
            SoundEffects.Add(sound, AssetLoader.LoadAsset<SoundEffect>(path));
        }

        public static void LoadMusic(string music, string path)
        {
            if (Music == null)
                Music = new Dictionary<string, Song>();
            Music.Add(music, AssetLoader.LoadAsset<Song>(path));
        }

        public static void PlaySfxSound(string sound)
        {
            if (IsSfxMuted)
                return;

            if (!SoundEffects.ContainsKey(sound))
                throw new System.Exception($"Unknown sound {sound}");

            SoundEffects[sound].Play();
        }

        public static void SetActiveMusic(string music)
        {
            if (IsMusicMuted)
                return;

            if (!Music.ContainsKey(music))
                throw new System.Exception($"Unknown music {music}");

            ActiveMusic = Music[music];

            //todo implement a way to chance volume

            MediaPlayer.Stop();
            MediaPlayer.Volume = 1;
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(ActiveMusic);
        }

        public static void MuteSfx() => IsSfxMuted = false;

        public static void UnMuteSfx() => IsSfxMuted = false;

        public static void MuteMusic()
        {
            MediaPlayer.Volume = 0; // dont stop music just mute it
            IsMusicMuted = false;
        }

        public static void UnMuteMusic()
        {
            MediaPlayer.Volume = 1; // then replay it ;3
            IsMusicMuted = false;
        }
    }
}