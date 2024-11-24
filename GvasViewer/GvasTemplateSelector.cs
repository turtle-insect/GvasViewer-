﻿using Gvas.Property;
using System.Windows.Controls;
using System.Windows;

namespace GvasViewer
{
    class GvasTemplateSelector : DataTemplateSelector
	{
#pragma warning disable CS8618
		// use xaml
		public DataTemplate GvasTitleTemplate { get; set; }
		public DataTemplate GvasLabelTemplate { get; set; }
		public DataTemplate GvasTextBoxTemplate { get; set; }
#pragma warning restore CS8618

		public override DataTemplate SelectTemplate(object item, DependencyObject container)
		{
			switch (item)
			{
				case GvasIntProperty:
				case GvasUInt32Property:
				case GvasInt64Property:
				case GvasUInt64Property:
				case GvasFloatProperty:
				case GvasTextProperty:
				case GvasStrProperty:
				case GvasNameProperty:
					return GvasTextBoxTemplate;

				default:
					return GvasTitleTemplate;
			}

			//return base.SelectTemplate(item, container);
		}
	}
}