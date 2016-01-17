﻿using MusicConcept.Common;
using MusicConcept.Library;
using MusicConcept.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace MusicConcept
{
    public sealed partial class ArtistPage : AppPage
    {
        public ArtistPage()
        {
            this.InitializeComponent();

            this.NavigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.NavigationHelper.SaveState += this.NavigationHelper_SaveState;
        }


        private async void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
            this.DataContext = await ViewModel.Instance.GetArtistViewModel((string)e.NavigationParameter);
            if (this.DataContext == null)
                this.NavigationHelper.GoBack();
        }

        private void NavigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
        }

        
        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var song = (Song)e.ClickedItem;
            ViewModel.Instance.GoToPlayMode(song, SongSource.ArtistSource(song.Artist));

            this.Frame.Navigate(typeof(NowPlayingPage));
        }

        private void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Frame.Navigate(typeof(AlbumPage), ((Album)e.ClickedItem).ArtistAndAlbum);
        }
    }
}
