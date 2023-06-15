using CommunityToolkit.Mvvm.ComponentModel;
using NewsApp.Services;

namespace NewsApp.ViewModels
{
	public partial class MainViewModel: ViewModel
	{
		private readonly INewsService _newsService;
		public MainViewModel(INewsService newsService)
		{
			_newsService = newsService;					
		}

		[ObservableProperty]
		private ObservableCollection<NewsItem> items = new();
        public override async Task Initialize()
        {
            await base.Initialize();

			try
			{
				IsBusy = true;
                var data = await _newsService.Get();

                Items = new(data);
            }
			catch(Exception ex)
			{
				// TODO handle ex
			}
			IsBusy = false;
        }
    }
}

