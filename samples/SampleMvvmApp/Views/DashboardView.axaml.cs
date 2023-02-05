﻿using Avalonia;
using Avalonia.Controls;
using Prism.Ioc;
using SampleMvvmApp.Services;

namespace SampleMvvmApp.Views;

/// <summary>DashboardView.</summary>
public partial class DashboardView : UserControl
{
    public DashboardView()
    {
        InitializeComponent();
    }

    protected override void OnAttachedToVisualTree(VisualTreeAttachmentEventArgs e)
    {
        base.OnAttachedToVisualTree(e);

        // Initialize the WindowNotificationManager with the MainWindow
        var notifyService = ContainerLocator.Current.Resolve<INotificationService>();
        notifyService.SetHostWindow(TopLevel.GetTopLevel(this));
    }
}
