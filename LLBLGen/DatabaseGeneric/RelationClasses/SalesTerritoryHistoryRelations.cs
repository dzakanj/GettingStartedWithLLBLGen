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
	/// <summary>Implements the relations factory for the entity: SalesTerritoryHistory. </summary>
	public partial class SalesTerritoryHistoryRelations
	{
		/// <summary>CTor</summary>
		public SalesTerritoryHistoryRelations()
		{
		}

		/// <summary>Gets all relations of the SalesTerritoryHistoryEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.SalesPersonEntityUsingBusinessEntityId);
			toReturn.Add(this.SalesTerritoryEntityUsingTerritoryId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between SalesTerritoryHistoryEntity and SalesPersonEntity over the m:1 relation they have, using the relation between the fields:
		/// SalesTerritoryHistory.BusinessEntityId - SalesPerson.BusinessEntityId
		/// </summary>
		public virtual IEntityRelation SalesPersonEntityUsingBusinessEntityId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "SalesPerson", false);
				relation.AddEntityFieldPair(SalesPersonFields.BusinessEntityId, SalesTerritoryHistoryFields.BusinessEntityId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SalesPersonEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SalesTerritoryHistoryEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between SalesTerritoryHistoryEntity and SalesTerritoryEntity over the m:1 relation they have, using the relation between the fields:
		/// SalesTerritoryHistory.TerritoryId - SalesTerritory.TerritoryId
		/// </summary>
		public virtual IEntityRelation SalesTerritoryEntityUsingTerritoryId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "SalesTerritory", false);
				relation.AddEntityFieldPair(SalesTerritoryFields.TerritoryId, SalesTerritoryHistoryFields.TerritoryId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SalesTerritoryEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SalesTerritoryHistoryEntity", true);
				return relation;
			}
		}
		/// <summary>stub, not used in this entity, only for TargetPerEntity entities.</summary>
		public virtual IEntityRelation GetSubTypeRelation(string subTypeEntityName) { return null; }
		/// <summary>stub, not used in this entity, only for TargetPerEntity entities.</summary>
		public virtual IEntityRelation GetSuperTypeRelation() { return null;}
		#endregion

		#region Included Code

		#endregion
	}
	
	/// <summary>Static class which is used for providing relationship instances which are re-used internally for syncing</summary>
	internal static class StaticSalesTerritoryHistoryRelations
	{
		internal static readonly IEntityRelation SalesPersonEntityUsingBusinessEntityIdStatic = new SalesTerritoryHistoryRelations().SalesPersonEntityUsingBusinessEntityId;
		internal static readonly IEntityRelation SalesTerritoryEntityUsingTerritoryIdStatic = new SalesTerritoryHistoryRelations().SalesTerritoryEntityUsingTerritoryId;

		/// <summary>CTor</summary>
		static StaticSalesTerritoryHistoryRelations()
		{
		}
	}
}
