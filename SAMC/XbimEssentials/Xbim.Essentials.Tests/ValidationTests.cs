﻿using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Ifc;
using Xbim.Ifc.Validation;
using Xbim.Ifc2x3.HVACDomain;
using Xbim.Ifc2x3.Kernel;

namespace Xbim.Essentials.Tests
{
    [TestClass]
    public class ValidationTests
    {
        [TestMethod]
        [DeploymentItem("TestSourceFiles")]
        public void ValidatesFile()
        {
            const string file = "InvalidContentFC4.ifc";
            using (var model = IfcStore.Open(file, null, 0))
            {
                //var v2 = model.Metadata.Types()
                //    .Where(x => x.Properties.Any(pr => pr.Value.EntityAttribute.State == EntityAttributeState.Mandatory
                //    && typeof(IExpressValueType).IsAssignableFrom(pr.Value.PropertyInfo.PropertyType)
                //    ));
                var v = new IfcValidator
                {
                    ValidateLevel = ValidationFlags.All,
                    CreateEntityHierarchy = true
                };
                var errors = v.Validate(model);
                foreach (var validationResult in new IfcValidationReporter(errors))
                {
                    Debug.WriteLine(validationResult);
                }
            }
        }

        [TestMethod]
        [DeploymentItem("TestSourceFiles")]
        public void ValidatesEntity()
        {
            using (var model = IfcStore.Open("InvalidContentFC4.ifc", null, 0))
            {
                //var v2 = model.Metadata.Types()
                //    .Where(x => x.Properties.Any(pr => pr.Value.EntityAttribute.State == EntityAttributeState.Mandatory
                //    && typeof(IExpressValueType).IsAssignableFrom(pr.Value.PropertyInfo.PropertyType)
                //    ));
                var v = new IfcValidator
                {
                    ValidateLevel = ValidationFlags.All,
                    CreateEntityHierarchy = true
                };
                var e2 = v.Validate(model.Instances[202]);
                foreach (var validationResult in new IfcValidationReporter(e2))
                {
                    Debug.WriteLine(validationResult);
                }
            }
        }


        [TestMethod]
        [DeploymentItem("TestSourceFiles")]
        public void ValidatesSpecificElements2X4()
        {
            using (var model = IfcStore.Open("AlmostEmptyIFC4.ifc", null, 0))
            {
                var v = new IfcValidator
                {
                    ValidateLevel = ValidationFlags.All,
                    CreateEntityHierarchy = true
                };

                var iCount = 0;
                var e2 = v.Validate(model.Instances[9]);
                foreach (var validationResult in new IfcValidationReporter(e2))
                {
                    Debug.WriteLine(validationResult);
                    iCount++;
                }

                if (iCount != 0)
                    throw new Exception("Unexpected validation error.");
            }
        }

        [TestMethod]
        [DeploymentItem("TestSourceFiles")]
        public void ValidatesSpecificElements2X3()
        {
            using (var model = IfcStore.Open("ValidationTests2x3.ifc", null, 0))
            {
                var v = new IfcValidator
                {
                    ValidateLevel = ValidationFlags.All,
                    CreateEntityHierarchy = true
                };
                var item = model.Instances[100] as IfcCoilType;
                if (item == null)
                    throw  new Exception();

                var e2 = v.Validate(item);
                int iCount = 0;
                foreach (var validationResult in new IfcValidationReporter(e2))
                {
                    Debug.WriteLine(validationResult);
                    iCount++;
                }

                e2 = v.Validate(model.Instances[9]);
                foreach (var validationResult in new IfcValidationReporter(e2))
                {
                    Debug.WriteLine(validationResult);
                    iCount++;
                }
                
                if (iCount != 0)
                    throw  new Exception("Unexpected validation error.");

                //bool res;
                //Debug.WriteLine("fcCoilTypeClause.WR1" + item.ValidateClause(IfcCoilType.IfcCoilTypeClause.WR1));
                //Debug.WriteLine("fcCoilTypeClause.WR1" + item.ValidateClause(IfcTypeObject.IfcTypeObjectClause.WR1));
                //Debug.WriteLine("fcCoilTypeClause.WR1" + item.ValidateClause(IfcTypeProduct.IfcTypeProductClause.WR41));
            }
        }
    }
}