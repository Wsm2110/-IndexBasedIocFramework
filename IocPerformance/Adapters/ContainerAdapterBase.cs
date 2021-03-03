using System;
using System.Linq;
using System.Xml.Linq;
using IocPerformance.Classes.AspNet;

namespace IocPerformance.Adapters
{
    public abstract class ContainerAdapterBase : IContainerAdapter
    {
        public virtual string Version
        {
            get
            {
                XNamespace ns = "http://schemas.microsoft.com/developer/msbuild/2003";

                return XDocument
                   .Load("../../IocPerformance.csproj")
                   .Root
                   .Descendants(ns + "PackageReference")
                   .First(e => e.Attribute("Include").Value == this.PackageName)
                   .Element(ns + "Version").Value;
            }
        }

        public virtual string Name => this.PackageName;

        public abstract string PackageName
        {
            get;
        }

        public abstract string Url
        {
            get;
        }

        public virtual bool SupportsInterception => false;

        public virtual bool SupportsPropertyInjection => false;

        public virtual bool SupportsChildContainer => false;

        public virtual bool SupportAspNetCore => false;

        public virtual bool SupportsConditional => false;

        public virtual bool SupportGeneric => false;

        public virtual bool SupportsMultiple => false;

        public virtual bool SupportsTransient => true;

        public virtual bool SupportsCombined => true;

        public virtual bool SupportsBasic => true;

        public abstract void PrepareBasic();

        public override string ToString()
        {
            return this.Name;
        }

        public virtual void Prepare()
        {
            this.PrepareBasic(); // by default any prepare should at least support basic one
        }

        public abstract object Resolve(Type type);

        public abstract object Resolve(int index);
        

        public abstract void Dispose();

        protected void RegisterAspNetCoreClasses()
        {
         
        }

    }
}