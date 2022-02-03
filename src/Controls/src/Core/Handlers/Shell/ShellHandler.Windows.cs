using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Maui.Controls.Platform;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Handlers;

namespace Microsoft.Maui.Controls.Handlers
{
	public partial class ShellHandler : ViewHandler<Shell, ShellView>
	{
		protected override ShellView CreatePlatformView()
		{
			return new ShellView();
		}

		public override Size GetDesiredSize(double widthConstraint, double heightConstraint)
		{
			return PlatformView.GetDesiredSize(widthConstraint, heightConstraint);
		}

		public override void SetVirtualView(IView view)
		{
			base.SetVirtualView(view);
			PlatformView.SetElement((Shell)view);
		}
	}
}
