﻿using Avalonia;
using Prism.Extensions;
using System;

namespace Prism.Regions
{
    /// <summary>
    /// Defines a class that wraps an item and adds metadata for it.
    /// </summary>
    public class ItemMetadata : AvaloniaObject
    {
        /// <summary>
        /// The name of the wrapped item.
        /// </summary>
        public static readonly StyledProperty<string> NameProperty =
            AvaloniaProperty.Register<ItemMetadata, string>("Name");

        /// <summary>
        /// Value indicating whether the wrapped item is considered active.
        /// </summary>
        public static readonly StyledProperty<bool> IsActiveProperty =
            AvaloniaProperty.Register<ItemMetadata, bool>("IsActive");

        /// <summary>
        /// Initializes a new instance of <see cref="ItemMetadata"/>.
        /// </summary>
        /// <param name="item">The item to wrap.</param>
        public ItemMetadata(object item)
        {
            // check for null
            this.Item = item;
        }

        static ItemMetadata()
        {
            IsActiveProperty.Changed.Subscribe(args => StyledPropertyChanged(args?.Sender, args));
        }

        /// <summary>
        /// Gets the wrapped item.
        /// </summary>
        /// <value>The wrapped item.</value>
        public object Item { get; private set; }

        /// <summary>
        /// Gets or sets a name for the wrapped item.
        /// </summary>
        /// <value>The name of the wrapped item.</value>
        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the wrapped item is considered active.
        /// </summary>
        /// <value><see langword="true" /> if the item should be considered active; otherwise <see langword="false" />.</value>
        public bool IsActive
        {
            get { return (bool)GetValue(IsActiveProperty); }
            set { SetValue(IsActiveProperty, value); }
        }

        /// <summary>
        /// Occurs when metadata on the item changes.
        /// </summary>
        public event EventHandler MetadataChanged;

        /// <summary>
        /// Explicitly invokes <see cref="MetadataChanged"/> to notify listeners.
        /// </summary>
        public void InvokeMetadataChanged()
        {
            EventHandler metadataChangedHandler = MetadataChanged;
            if (metadataChangedHandler != null) metadataChangedHandler(this, EventArgs.Empty);
        }

        private static void StyledPropertyChanged(AvaloniaObject dependencyObject, AvaloniaPropertyChangedEventArgs args)
        {
            ItemMetadata itemMetadata = dependencyObject as ItemMetadata;
            if (itemMetadata != null)
            {
                itemMetadata.InvokeMetadataChanged();
            }
        }
    }
}
