using IFCModelConverter.Ifc_2x3_modified.IFCReader;
using SAMC2.ModelConverter;
using SapConverter.SapReader;
using SapConverter.SapWriter;
using StaadConverter.StaadWriter;
using StaadConverter.StaadReader;
using System;
using System.IO;
using System.Web;
using Unity;
using Unity.Injection;

namespace SAMCWebApp
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();
            //container.RegisterType<IDocumentSectionsWritersProvider, StaadDocumentSectionsWritersProvider>();
            //    container.RegisterType<IModelReader,IFCModelConverter.IFCModelConverter>();
            container.RegisterType<DocumentWriter>(new InjectionFactory(i=>GetWriter()));
            container.RegisterType<IModelReader>(new InjectionFactory(c => CreateModelReader()));
        }

        static IModelReader CreateModelReader()
        {
            var postedFiles = HttpContext.Current.Request.Files;
            if (postedFiles.Count == 0)
                return null;
            else
            {
                var fileExtension = Path.GetExtension(postedFiles[0].FileName).ToUpper();
                if (fileExtension.Equals(".IFC"))
                    return new IFCModelReader();
                else if (fileExtension.Equals(".$2K"))
                    return new SapReader();
                else if (fileExtension.Equals(".STD"))
                    return new StaadReader();
                else
                    return null;
            }
        }
        static DocumentWriter GetWriter()
        {
            if (HttpContext.Current.Request.RequestType.ToUpper().Equals("GET"))          
                return  null;
            
            var writer = HttpContext.Current.Request.Form["writer"];
            
                if (writer.Equals("std"))
                    return new StaadWriter(new StaadDocumentSectionsWritersProvider());
                else if (writer.Equals("$2k"))
                    return new SapWriter(new SapDocumentSectionWriterProvider());
                else
                    return new IFCModelConverter.Ifc_2x3_modified.IFCWriter.IfcWriter(null);
           
        }
    }
}