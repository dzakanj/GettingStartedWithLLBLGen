using AdventureWorksLLBLGen.DatabaseSpecific;
using AdventureWorksLLBLGen.EntityClasses;
using AdventureWorksLLBLGen.FactoryClasses;
using AdventureWorksLLBLGen.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using SD.LLBLGen.Pro.QuerySpec;
using SD.LLBLGen.Pro.QuerySpec.Adapter;
using System;
using System.Linq;

namespace ConsoleTester
{
    class Program
    {
        static void Main(string[] args)
        {
            //Call the method you want to test eg Get,Insert,Update,Delete
            try
            {
                GetEmployees();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            Console.WriteLine("DONE!");
            Console.ReadLine();
        }

        /// <summary>
        /// Get the EmployeesEntitiy collection.
        /// </summary>
        private static void GetEmployees()
        {
            var employees = new EntityCollection<EmployeeEntity>();
            using (var adapter = new DataAccessAdapter())
            {
                var qf = new QueryFactory();
                //Change the method to generate different fetch query
                var q = GetAllEmployees(qf);

                adapter.FetchQuery(q, employees);
            }

            //If using the GetFilteredEmployeesWithPerson() you can output the 'PersonEntity' properties
            for (int i = 0; i < 5; i++)
            {
                var employee = employees[i];
                Console.WriteLine($"The employee number {employee.BusinessEntityId} is working as a {employee.JobTitle}");
            }
        }

        /// <summary>
        /// Get all employees.
        /// </summary>
        /// <param name="qf">Query Factory object</param>
        /// <returns></returns>
        private static EntityQuery<EmployeeEntity> GetAllEmployees(QueryFactory qf)
        {
            return qf.Employee;
        }

        /// <summary>
        /// Get the employees with limit.
        /// </summary>
        /// <param name="qf">Query Factory object</param>
        /// <returns></returns>
        private static EntityQuery<EmployeeEntity> GetEmployeesWithLimit(QueryFactory qf)
        {
            return qf.Employee.Limit(5);
        }

        /// <summary>
        /// Get the employees with limit and offset.
        /// </summary>
        /// <param name="qf">Query Factory object</param>
        /// <returns></returns>
        private static EntityQuery<EmployeeEntity> GetEmployeesWithLimitAndOffset(QueryFactory qf)
        {
            return qf.Employee.OrderBy(EmployeeFields.BusinessEntityId.Ascending()).Offset(10).Limit(5);
        }

        /// <summary>
        /// Get the paged employees resultset.
        /// </summary>
        /// <param name="qf">Query Factory object</param>
        /// <returns></returns>
        private static EntityQuery<EmployeeEntity> GetPagedEmployees(QueryFactory qf)
        {
            return qf.Employee.OrderBy(EmployeeFields.BusinessEntityId.Ascending()).Page(3, 5);
        }

        /// <summary>
        /// Get the filtered employees using generated relations.
        /// </summary>
        /// <param name="qf">Query Factory object</param>
        /// <returns></returns>
        private static EntityQuery<EmployeeEntity> GetFilteredEmployeesUsingRelations(QueryFactory qf)
        {
            return qf.Employee.
                   From(QueryTarget.
                   InnerJoin(EmployeeEntity.Relations.PersonEntityUsingBusinessEntityId)).
                   Where(PersonFields.FirstName.StartsWith("A")).
                   AndWhere(EmployeeFields.Gender == "M").
                   OrderBy(EmployeeFields.BusinessEntityId.Ascending()).
                   Limit(5);
        }

        /// <summary>
        /// Get the filtered employeed by specifying primary and foreign key contraints
        /// </summary>
        /// <param name="qf">Query Factory object</param>
        /// <returns></returns>
        private static EntityQuery<EmployeeEntity> GetFilteredEmployeesUsingContraints(QueryFactory qf)
        {
            return qf.Employee.
                   From(QueryTarget.
                   InnerJoin(qf.Person).On(PersonFields.BusinessEntityId == EmployeeFields.BusinessEntityId)).
                   Where(PersonFields.FirstName.StartsWith("A")).
                   AndWhere(EmployeeFields.Gender == "M").
                   OrderBy(EmployeeFields.BusinessEntityId.Ascending()).
                   Limit(5);
        }

        /// <summary>
        /// Get the filtered employees with prefetched Person entities
        /// </summary>
        /// <param name="qf">Query Factory object</param>
        /// <returns></returns>
        private static EntityQuery<EmployeeEntity> GetFilteredEmployeesWithPerson(QueryFactory qf)
        {
            return qf.Employee.
                   From(QueryTarget.
                   InnerJoin(qf.Person).On(PersonFields.BusinessEntityId == EmployeeFields.BusinessEntityId)).
                   Where(PersonFields.FirstName.StartsWith("A")).
                   AndWhere(EmployeeFields.Gender == "M").
                   OrderBy(EmployeeFields.BusinessEntityId.Ascending()).
                   Limit(5).
                   WithPath(EmployeeEntity.PrefetchPathPerson);
        }

        /// <summary>
        /// Insert BusinessEntity to get the BusinessEntityId
        /// Insert the new person with refetch on save entity.
        /// </summary>
        private static void InsertNewPerson()
        {
            var newBusinessEntity = new BusinessEntityEntity
            {
                ModifiedDate = DateTime.UtcNow,
                Rowguid = Guid.NewGuid()
            };

            using (var adapter = new DataAccessAdapter())
            {
                adapter.SaveEntity(newBusinessEntity);
            }

            var newPerson = new PersonEntity
            {
                BusinessEntityId = newBusinessEntity.BusinessEntityId,
                PersonType = "EM",
                NameStyle = false,
                Title = "Mr",
                FirstName = "John",
                LastName = "Doe",
                EmailPromotion = 1,
                Rowguid = Guid.NewGuid(),
                ModifiedDate = DateTime.UtcNow
            };

            using (var adapter = new DataAccessAdapter())
            {
                adapter.SaveEntity(newPerson, true);
            }

            Console.WriteLine($"{newPerson.Title}. {newPerson.FirstName} {newPerson.LastName} has just been inserted!");
        }

        /// <summary>
        /// Updates the person by identifier.
        /// </summary>
        /// <param name="businessEntityId">The business entity identifier.</param>
        public static void UpdatePersonById(int businessEntityId)
        {
            var person = new PersonEntity(businessEntityId);
            using (var adapter = new DataAccessAdapter())
            {
                adapter.FetchEntity(person);
                person.FirstName = "Jane";
                person.Title = "Ms";
                person.ModifiedDate = DateTime.UtcNow;
                adapter.SaveEntity(person);
            }
        }

        /// <summary>
        /// Updates the person by identifier directly.
        /// </summary>
        /// <param name="businessEntityId">The business entity identifier.</param>
        public static void UpdatePersonByIdDirectly(int businessEntityId)
        {
            RelationPredicateBucket filterBucket = new RelationPredicateBucket(PersonFields.BusinessEntityId == businessEntityId);
            PersonEntity updatePerson = new PersonEntity()
            {
                FirstName = "Jane",
                Title = "Ms",
                ModifiedDate = DateTime.UtcNow
            };

            using (var adapter = new DataAccessAdapter())
            {
                adapter.UpdateEntitiesDirectly(updatePerson, filterBucket);
            }
        }

        /// <summary>
        /// Deletes the person by identifier.
        /// </summary>
        /// <param name="businessEntityId">The business entity identifier.</param>
        public static void DeletePersonById(int businessEntityId)
        {
            using (var adapter = new DataAccessAdapter())
            {
                var personToDelete = new PersonEntity(businessEntityId);
                adapter.FetchEntity(personToDelete);
                adapter.DeleteEntity(personToDelete);
            }
        }

        /// <summary>
        /// Deletes the person by identifier directly.
        /// </summary>
        /// <param name="businessEntityId">The business entity identifier.</param>
        public static void DeletePersonByIdDirectly(int businessEntityId)
        {
            using (var adapter = new DataAccessAdapter())
            {
                var personToDelete = new PersonEntity(businessEntityId);
                adapter.DeleteEntity(personToDelete);
            }
        }

        /// <summary>
        /// Deletes the person by identifier directly using predicate bucket.
        /// </summary>
        /// <param name="businessEntityId">The business entity identifier.</param>
        public static void DeletePersonByIdDirectlyUsingPredicateBucket(int businessEntityId)
        {
            using (var adapter = new DataAccessAdapter())
            {
                RelationPredicateBucket filterBucket = new RelationPredicateBucket(PersonFields.BusinessEntityId == businessEntityId);
                adapter.DeleteEntitiesDirectly(typeof(PersonEntity), filterBucket);
            }
        }
    }
}
