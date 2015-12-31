using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;

namespace XElement.CloudSyncHelper.UI.Win32.Localization
{
    [TestClass]
    public class testLocalization
    {
        [TestCleanup]
        public void TestCleanup()
        {
            Localization.Culture = CultureInfo.InvariantCulture;
        }

        [TestMethod]
        public void testLocalization_DictionariesAreEquivalent_defaultVsDeDE()
        {
            var default_resourceSet = GetResourceSet();
            var deDE_resourceSet = GetResourceSet( "de-DE" );
            var default_dictionaryEntries = ConvertResourceSetToDictionaryEntries( default_resourceSet );
            var deDE_dictionaryEntries = ConvertResourceSetToDictionaryEntries( deDE_resourceSet );
            var default_Keys = default_dictionaryEntries.Select( de => (string)de.Key ).ToList();
            var deDE_Keys = deDE_dictionaryEntries.Select( de => (string)de.Key ).ToList();
            CollectionAssert.AreEquivalent( default_Keys, deDE_Keys );
        }

        [TestMethod]
        public void testLocalization_Default_NoEmptyEntry()
        {
            var resourceSet = GetResourceSet();

            var dictionaryEntries = ConvertResourceSetToDictionaryEntries( resourceSet );
            var values = dictionaryEntries.Select( de => (string)de.Value ).ToList();
            Assert.IsTrue( values.Count > 0 );
            CollectionAssert.AllItemsAreNotNull( values );
            CollectionAssert.DoesNotContain( values, String.Empty, "At least one entry equals to 'String.Empty'." );
        }

        [TestMethod]
        public void testLocalization_deDE_NoEmptyEntry()
        {
            var resourceSet = GetResourceSet( "de-DE" );

            var dictionaryEntries = ConvertResourceSetToDictionaryEntries( resourceSet );
            var values = dictionaryEntries.Select( de => (string)de.Value ).ToList();
            Assert.IsTrue( values.Count > 0 );
            CollectionAssert.AllItemsAreNotNull( values );
            CollectionAssert.DoesNotContain( values, String.Empty, "At least one entry equals to 'String.Empty'." );
        }


        private static IEnumerable<DictionaryEntry> ConvertResourceSetToDictionaryEntries( ResourceSet resourceSet )
        {
            var dictionaryEntries = new List<DictionaryEntry>();

            foreach ( DictionaryEntry entry in resourceSet )
            {
                dictionaryEntries.Add( entry );
            }

            return dictionaryEntries;
        }

        private static ResourceSet GetResourceSet( string cultureName, bool tryParents )
        {
            var culture = new CultureInfo( cultureName );
            var resourceSet = Localization.ResourceManager.GetResourceSet( culture, 
                                                                           createIfNotExists: true, 
                                                                           tryParents: tryParents );
            return resourceSet;
        }
        private static ResourceSet GetResourceSet( string cultureName )
        {
            return GetResourceSet( cultureName, false );
        }
        private static ResourceSet GetResourceSet()
        {
            var isDefault = true;
            return GetResourceSet( String.Empty, isDefault );
        }
    }
}
