using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Devices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        public async Task Play()
        {
            var musicLibrary = await StorageLibrary.GetLibraryAsync(KnownLibraryId.Music);
            var musicFolder = musicLibrary.Folders.FirstOrDefault();
            StorageFile file = await musicFolder.GetFileAsync("song.mid");
            MidiFile midiFile;
            using (var stream = await file.OpenStreamForReadAsync().ConfigureAwait(true))
            {
                midiFile = MidiFile.Read(stream, new ReadingSettings { NotEnoughBytesPolicy = NotEnoughBytesPolicy.Ignore });
            }

            var outputDevice = OutputDevice.GetByName("Microsoft GS Wavetable Synth");
            var playback = midiFile.GetPlayback(outputDevice);
            playback.Speed = 2.0;
            playback.Play();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Play();
        }
    }
}
