#nullable enable
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;

namespace Microsoft.Maui.Handlers
{
	// To avoid an issue rendering the native ProgressBar on Windows, we wrap it into a Container.
	public partial class ProgressBarHandler : ViewHandler<IProgress, Grid>
	{
		object? _foregroundDefault;

		protected override Grid CreatePlatformView() =>
			new Grid();

		public ProgressBar? ProgressBar { get; internal set; }

		protected override void ConnectHandler(Grid platformView)
		{
			ProgressBar = new ProgressBar { Minimum = 0, Maximum = 1 };
			platformView.Children.Add(ProgressBar);
			ProgressBar.ValueChanged += OnProgressBarValueChanged;

			SetupDefaults(ProgressBar);
		}

		protected override void DisconnectHandler(Grid platformView)
		{
			if (ProgressBar != null)
				ProgressBar.ValueChanged -= OnProgressBarValueChanged;
		}

		void SetupDefaults(ProgressBar platformView)
		{
			_foregroundDefault = platformView.GetForegroundCache();
		}

		public static void MapProgress(ProgressBarHandler handler, IProgress progress)
		{
			handler.ProgressBar?.UpdateProgress(progress);
		}

		public static void MapProgressColor(ProgressBarHandler handler, IProgress progress)
		{
			handler.ProgressBar?.UpdateProgressColor(progress, handler._foregroundDefault);
		}

		void OnProgressBarValueChanged(object? sender, RangeBaseValueChangedEventArgs rangeBaseValueChangedEventArgs)
		{
			VirtualView?.InvalidateMeasure();
		}
	}
}