﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace lesFiltres.Models
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="progra_web")]
	public partial class WPFTutorialEntities1DataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Définitions de méthodes d'extensibilité
    partial void OnCreated();
    #endregion
		
		public WPFTutorialEntities1DataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["progra_webConnectionString1"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public WPFTutorialEntities1DataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public WPFTutorialEntities1DataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public WPFTutorialEntities1DataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public WPFTutorialEntities1DataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Users> Users
		{
			get
			{
				return this.GetTable<Users>();
			}
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.CheckIfThisUserExist")]
		public ISingleResult<CheckIfThisUserExistResult> CheckIfThisUserExist([global::System.Data.Linq.Mapping.ParameterAttribute(Name="UserName", DbType="NVarChar(1)")] string userName, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Passwd", DbType="NVarChar(1)")] string passwd)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), userName, passwd);
			return ((ISingleResult<CheckIfThisUserExistResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.ValidateUser")]
		public ISingleResult<ValidateUserResult> ValidateUser([global::System.Data.Linq.Mapping.ParameterAttribute(Name="Name", DbType="NVarChar(1)")] string name, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Passwd", DbType="NVarChar(1)")] string passwd)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), name, passwd);
			return ((ISingleResult<ValidateUserResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.GetRoleOfUser")]
		public ISingleResult<GetRoleOfUserResult> GetRoleOfUser([global::System.Data.Linq.Mapping.ParameterAttribute(Name="UserName", DbType="NVarChar(1)")] string userName)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), userName);
			return ((ISingleResult<GetRoleOfUserResult>)(result.ReturnValue));
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Users")]
	public partial class Users
	{
		
		private int _id;
		
		private string _UserName;
		
		private string _Passwd;
		
		public Users()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.Always, DbType="Int NOT NULL IDENTITY", IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this._id = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string UserName
		{
			get
			{
				return this._UserName;
			}
			set
			{
				if ((this._UserName != value))
				{
					this._UserName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Passwd", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Passwd
		{
			get
			{
				return this._Passwd;
			}
			set
			{
				if ((this._Passwd != value))
				{
					this._Passwd = value;
				}
			}
		}
	}
	
	public partial class CheckIfThisUserExistResult
	{
		
		private System.Nullable<int> _Column1;
		
		public CheckIfThisUserExistResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="", Storage="_Column1", DbType="Int")]
		public System.Nullable<int> Column1
		{
			get
			{
				return this._Column1;
			}
			set
			{
				if ((this._Column1 != value))
				{
					this._Column1 = value;
				}
			}
		}
	}
	
	public partial class ValidateUserResult
	{
		
		private System.Nullable<int> _Column1;
		
		public ValidateUserResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="", Storage="_Column1", DbType="Int")]
		public System.Nullable<int> Column1
		{
			get
			{
				return this._Column1;
			}
			set
			{
				if ((this._Column1 != value))
				{
					this._Column1 = value;
				}
			}
		}
	}
	
	public partial class GetRoleOfUserResult
	{
		
		private string _Name;
		
		public GetRoleOfUserResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(50)")]
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
					this._Name = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
