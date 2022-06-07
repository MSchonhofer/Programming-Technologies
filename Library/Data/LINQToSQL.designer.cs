﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Data
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="library")]
	public partial class LINQToSQLDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertAction(Action instance);
    partial void UpdateAction(Action instance);
    partial void DeleteAction(Action instance);
    partial void InsertBook(Book instance);
    partial void UpdateBook(Book instance);
    partial void DeleteBook(Book instance);
    partial void InsertCatalog(Catalog instance);
    partial void UpdateCatalog(Catalog instance);
    partial void DeleteCatalog(Catalog instance);
    partial void InsertReader(Reader instance);
    partial void UpdateReader(Reader instance);
    partial void DeleteReader(Reader instance);
    #endregion
		
		public LINQToSQLDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public LINQToSQLDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public LINQToSQLDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public LINQToSQLDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Action> Action
		{
			get
			{
				return this.GetTable<Action>();
			}
		}
		
		public System.Data.Linq.Table<Book> Book
		{
			get
			{
				return this.GetTable<Book>();
			}
		}
		
		public System.Data.Linq.Table<Catalog> Catalog
		{
			get
			{
				return this.GetTable<Catalog>();
			}
		}
		
		public System.Data.Linq.Table<Reader> Reader
		{
			get
			{
				return this.GetTable<Reader>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Action")]
	public partial class Action : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _ActionType;
		
		private System.Nullable<int> _BookID;
		
		private EntityRef<Book> _Book;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnActionTypeChanging(string value);
    partial void OnActionTypeChanged();
    partial void OnBookIDChanging(System.Nullable<int> value);
    partial void OnBookIDChanged();
    #endregion
		
		public Action()
		{
			this._Book = default(EntityRef<Book>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActionType", DbType="VarChar(50) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string ActionType
		{
			get
			{
				return this._ActionType;
			}
			set
			{
				if ((this._ActionType != value))
				{
					this.OnActionTypeChanging(value);
					this.SendPropertyChanging();
					this._ActionType = value;
					this.SendPropertyChanged("ActionType");
					this.OnActionTypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BookID", DbType="Int")]
		public System.Nullable<int> BookID
		{
			get
			{
				return this._BookID;
			}
			set
			{
				if ((this._BookID != value))
				{
					if (this._Book.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnBookIDChanging(value);
					this.SendPropertyChanging();
					this._BookID = value;
					this.SendPropertyChanged("BookID");
					this.OnBookIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Book_Action", Storage="_Book", ThisKey="BookID", OtherKey="BookID", IsForeignKey=true)]
		public Book Book
		{
			get
			{
				return this._Book.Entity;
			}
			set
			{
				Book previousValue = this._Book.Entity;
				if (((previousValue != value) 
							|| (this._Book.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Book.Entity = null;
						previousValue.Action.Remove(this);
					}
					this._Book.Entity = value;
					if ((value != null))
					{
						value.Action.Add(this);
						this._BookID = value.BookID;
					}
					else
					{
						this._BookID = default(Nullable<int>);
					}
					this.SendPropertyChanged("Book");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Book")]
	public partial class Book : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _BookID;
		
		private EntitySet<Action> _Action;
		
		private EntitySet<Catalog> _Catalog;
		
		private EntitySet<Reader> _Reader;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnBookIDChanging(int value);
    partial void OnBookIDChanged();
    #endregion
		
		public Book()
		{
			this._Action = new EntitySet<Action>(new Action<Action>(this.attach_Action), new Action<Action>(this.detach_Action));
			this._Catalog = new EntitySet<Catalog>(new Action<Catalog>(this.attach_Catalog), new Action<Catalog>(this.detach_Catalog));
			this._Reader = new EntitySet<Reader>(new Action<Reader>(this.attach_Reader), new Action<Reader>(this.detach_Reader));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BookID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int BookID
		{
			get
			{
				return this._BookID;
			}
			set
			{
				if ((this._BookID != value))
				{
					this.OnBookIDChanging(value);
					this.SendPropertyChanging();
					this._BookID = value;
					this.SendPropertyChanged("BookID");
					this.OnBookIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Book_Action", Storage="_Action", ThisKey="BookID", OtherKey="BookID")]
		public EntitySet<Action> Action
		{
			get
			{
				return this._Action;
			}
			set
			{
				this._Action.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Book_Catalog", Storage="_Catalog", ThisKey="BookID", OtherKey="BookID")]
		public EntitySet<Catalog> Catalog
		{
			get
			{
				return this._Catalog;
			}
			set
			{
				this._Catalog.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Book_Reader", Storage="_Reader", ThisKey="BookID", OtherKey="BookID")]
		public EntitySet<Reader> Reader
		{
			get
			{
				return this._Reader;
			}
			set
			{
				this._Reader.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Action(Action entity)
		{
			this.SendPropertyChanging();
			entity.Book = this;
		}
		
		private void detach_Action(Action entity)
		{
			this.SendPropertyChanging();
			entity.Book = null;
		}
		
		private void attach_Catalog(Catalog entity)
		{
			this.SendPropertyChanging();
			entity.Book = this;
		}
		
		private void detach_Catalog(Catalog entity)
		{
			this.SendPropertyChanging();
			entity.Book = null;
		}
		
		private void attach_Reader(Reader entity)
		{
			this.SendPropertyChanging();
			entity.Book = this;
		}
		
		private void detach_Reader(Reader entity)
		{
			this.SendPropertyChanging();
			entity.Book = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Catalog")]
	public partial class Catalog : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _Title;
		
		private string _Author;
		
		private System.Nullable<int> _BookID;
		
		private EntityRef<Book> _Book;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnTitleChanging(string value);
    partial void OnTitleChanged();
    partial void OnAuthorChanging(string value);
    partial void OnAuthorChanged();
    partial void OnBookIDChanging(System.Nullable<int> value);
    partial void OnBookIDChanged();
    #endregion
		
		public Catalog()
		{
			this._Book = default(EntityRef<Book>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Title", DbType="VarChar(50) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string Title
		{
			get
			{
				return this._Title;
			}
			set
			{
				if ((this._Title != value))
				{
					this.OnTitleChanging(value);
					this.SendPropertyChanging();
					this._Title = value;
					this.SendPropertyChanged("Title");
					this.OnTitleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Author", DbType="VarChar(50)")]
		public string Author
		{
			get
			{
				return this._Author;
			}
			set
			{
				if ((this._Author != value))
				{
					this.OnAuthorChanging(value);
					this.SendPropertyChanging();
					this._Author = value;
					this.SendPropertyChanged("Author");
					this.OnAuthorChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BookID", DbType="Int")]
		public System.Nullable<int> BookID
		{
			get
			{
				return this._BookID;
			}
			set
			{
				if ((this._BookID != value))
				{
					if (this._Book.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnBookIDChanging(value);
					this.SendPropertyChanging();
					this._BookID = value;
					this.SendPropertyChanged("BookID");
					this.OnBookIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Book_Catalog", Storage="_Book", ThisKey="BookID", OtherKey="BookID", IsForeignKey=true)]
		public Book Book
		{
			get
			{
				return this._Book.Entity;
			}
			set
			{
				Book previousValue = this._Book.Entity;
				if (((previousValue != value) 
							|| (this._Book.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Book.Entity = null;
						previousValue.Catalog.Remove(this);
					}
					this._Book.Entity = value;
					if ((value != null))
					{
						value.Catalog.Add(this);
						this._BookID = value.BookID;
					}
					else
					{
						this._BookID = default(Nullable<int>);
					}
					this.SendPropertyChanged("Book");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Reader")]
	public partial class Reader : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ReaderID;
		
		private string _Name;
		
		private string _Surname;
		
		private System.Nullable<int> _BookID;
		
		private EntityRef<Book> _Book;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnReaderIDChanging(int value);
    partial void OnReaderIDChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnSurnameChanging(string value);
    partial void OnSurnameChanged();
    partial void OnBookIDChanging(System.Nullable<int> value);
    partial void OnBookIDChanged();
    #endregion
		
		public Reader()
		{
			this._Book = default(EntityRef<Book>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ReaderID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int ReaderID
		{
			get
			{
				return this._ReaderID;
			}
			set
			{
				if ((this._ReaderID != value))
				{
					this.OnReaderIDChanging(value);
					this.SendPropertyChanging();
					this._ReaderID = value;
					this.SendPropertyChanged("ReaderID");
					this.OnReaderIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="VarChar(50)")]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Surname", DbType="VarChar(50)")]
		public string Surname
		{
			get
			{
				return this._Surname;
			}
			set
			{
				if ((this._Surname != value))
				{
					this.OnSurnameChanging(value);
					this.SendPropertyChanging();
					this._Surname = value;
					this.SendPropertyChanged("Surname");
					this.OnSurnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BookID", DbType="Int")]
		public System.Nullable<int> BookID
		{
			get
			{
				return this._BookID;
			}
			set
			{
				if ((this._BookID != value))
				{
					if (this._Book.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnBookIDChanging(value);
					this.SendPropertyChanging();
					this._BookID = value;
					this.SendPropertyChanged("BookID");
					this.OnBookIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Book_Reader", Storage="_Book", ThisKey="BookID", OtherKey="BookID", IsForeignKey=true)]
		public Book Book
		{
			get
			{
				return this._Book.Entity;
			}
			set
			{
				Book previousValue = this._Book.Entity;
				if (((previousValue != value) 
							|| (this._Book.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Book.Entity = null;
						previousValue.Reader.Remove(this);
					}
					this._Book.Entity = value;
					if ((value != null))
					{
						value.Reader.Add(this);
						this._BookID = value.BookID;
					}
					else
					{
						this._BookID = default(Nullable<int>);
					}
					this.SendPropertyChanged("Book");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591