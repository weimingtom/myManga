﻿using myMangaSiteExtension.Interfaces;
using System;
using System.Windows;

namespace myManga_App.Objects.Extensions
{
    public sealed class DatabaseExtensionObject : DependencyObject
    {
        #region Constructors
        public IDatabaseExtension DatabaseExtension
        { get; private set; }

        public DatabaseExtensionObject(IDatabaseExtension DatabaseExtension, Boolean Enabled)
            : base()
        {
            Update(DatabaseExtension, Enabled);
        }

        public void Update(IDatabaseExtension DatabaseExtension, Boolean Enabled)
        {
            this.DatabaseExtension = DatabaseExtension;
            Name = DatabaseExtension.DatabaseExtensionDescriptionAttribute.Name;
            this.Enabled = Enabled;
            IsAuthenticated = DatabaseExtension.IsAuthenticated;
        }

        public override string ToString()
        {
            return String.Format(
                "[DatabaseExtensionObject][{0}]{1}",
                Enabled ? "Enabled" : "Disabled",
                Name);
        }
        #endregion

        #region Name
        private static readonly DependencyPropertyKey NamePropertyKey = DependencyProperty.RegisterAttachedReadOnly(
            "Name",
            typeof(String),
            typeof(DatabaseExtensionObject),
            null);
        private static readonly DependencyProperty NameProperty = NamePropertyKey.DependencyProperty;

        public String Name
        {
            get { return (String)GetValue(NameProperty); }
            private set { SetValue(NamePropertyKey, value); }
        }
        #endregion

        #region Enabled
        private static readonly DependencyProperty EnabledProperty = DependencyProperty.RegisterAttached(
            "Enabled",
            typeof(Boolean),
            typeof(DatabaseExtensionObject),
            new PropertyMetadata(false));

        public Boolean Enabled
        {
            get { return (Boolean)GetValue(EnabledProperty); }
            set { SetValue(EnabledProperty, value); }
        }
        #endregion

        #region IsAuthenticated
        private static readonly DependencyPropertyKey IsAuthenticatedPropertyKey = DependencyProperty.RegisterAttachedReadOnly(
            "IsAuthenticated",
            typeof(Boolean),
            typeof(DatabaseExtensionObject),
            null);
        private static readonly DependencyProperty IsAuthenticatedProperty = IsAuthenticatedPropertyKey.DependencyProperty;

        public Boolean IsAuthenticated
        {
            get { return (Boolean)GetValue(IsAuthenticatedProperty); }
            private set { SetValue(IsAuthenticatedPropertyKey, value); }
        }
        #endregion
    }
}