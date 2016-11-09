using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PictureStampRally.Models;


namespace PictureStampRally.ViewModels
{
    public class ViewScorePageViewModel : NotificationBase
    {
        IEnumerable<ThemeInfo> _themeList;
        public IEnumerable<ThemeInfo> ThemeList
        {
            get { return _themeList; }
            private set
            {
                SetProperty(ref _themeList, value);
            }
        }

        ThemeInfo _selectedTheme;
        public ThemeInfo SelectedTheme
        {
            get { return _selectedTheme; }
            set
            {
                SetProperty(ref _selectedTheme, value);
            }
        }


        public async Task LoadThemeList()
        {
            using (var api = new PictureStampRallyWebApi())
            {
                ThemeList = await api.ThemeInfo.GetAsync(1);

                if (ThemeList.Any())
                {
                    SelectedTheme = ThemeList.First();
                }
            }
        }

    }
}
