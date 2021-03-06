﻿//////////////////////////////////////////////////////////////
// <auto-generated>This code was generated by LLBLGen Pro 5.3.</auto-generated>
//////////////////////////////////////////////////////////////
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
using System;
using System.Collections;
using System.Collections.Generic;
using AdventureWorksLLBLGen;
using AdventureWorksLLBLGen.FactoryClasses;
using AdventureWorksLLBLGen.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace AdventureWorksLLBLGen.RelationClasses
{
	/// <summary>Implements the relations factory for the entity: TransactionHistoryArchive. </summary>
	public partial class TransactionHistoryArchiveRelations
	{
		/// <summary>CTor</summary>
		public TransactionHistoryArchiveRelations()
		{
		}

		/// <summary>Gets all relations of the TransactionHistoryArchiveEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>stub, not used in this entity, only for TargetPerEntity entities.</summary>
		public virtual IEntityRelation GetSubTypeRelation(string subTypeEntityName) { return null; }
		/// <summary>stub, not used in this entity, only for TargetPerEntity entities.</summary>
		public virtual IEntityRelation GetSuperTypeRelation() { return null;}
		#endregion

		#region Included Code

		#endregion
	}
	
	/// <summary>Static class which is used for providing relationship instances which are re-used internally for syncing</summary>
	internal static class StaticTransactionHistoryArchiveRelations
	{

		/// <summary>CTor</summary>
		static StaticTransactionHistoryArchiveRelations()
		{
		}
	}
}
