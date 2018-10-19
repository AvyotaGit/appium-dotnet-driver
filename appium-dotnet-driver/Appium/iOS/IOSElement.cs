//Licensed under the Apache License, Version 2.0 (the "License");
//you may not use this file except in compliance with the License.
//See the NOTICE file distributed with this work for additional
//information regarding copyright ownership.
//You may obtain a copy of the License at
//
//   http://www.apache.org/licenses/LICENSE-2.0
//
//Unless required by applicable law or agreed to in writing, software
//distributed under the License is distributed on an "AS IS" BASIS,
//WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//See the License for the specific language governing permissions and
//limitations under the License.

using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace OpenQA.Selenium.Appium.iOS
{
    public class IOSElement : AppiumWebElement,
        IFindByIosUIAutomation<AppiumWebElement>, IFindsByIosNSPredicate<AppiumWebElement>, IFindsByIosClassChain<AppiumWebElement>
    {
        /// <summary>
        /// Initializes a new instance of the IOSElement class.
        /// </summary>
        /// <param name="parent">Driver in use.</param>
        /// <param name="id">ID of the element.</param>
        public IOSElement(RemoteWebDriver parent, string id)
            : base(parent, id)
        {
        }

        #region IFindByIosUIAutomation Members

        [Obsolete("Support for IOS UIAutomation is deprecated and will be removed in the next release." +
                         "Use FindElementByIosNSPredicate or FindElementByIosClassChain instead")]
        public AppiumWebElement FindElementByIosUIAutomation(string selector) =>
            FindElement(MobileSelector.iOSAutomatoion, selector);


        [Obsolete("Support for IOS UIAutomation is deprecated and will be removed in the next release." +
                         "Use FindElementsByIosNSPredicate or FindElementsByIosClassChain instead")]
        public ReadOnlyCollection<AppiumWebElement> FindElementsByIosUIAutomation(string selector) =>
            FindElements(MobileSelector.iOSAutomatoion, selector);

        #endregion IFindByIosUIAutomation Members

        #region IFindByIosNSPredicate Members

        public AppiumWebElement FindElementByIosNSPredicate(string selector) =>
            FindElement(MobileSelector.IosNSPredicateString, selector);

        public ReadOnlyCollection<AppiumWebElement> FindElementsByIosNSPredicate(string selector) =>
            FindElements(MobileSelector.IosNSPredicateString, selector);

        #endregion IFindByIosNSPredicate Members

        #region IFindsByIosClassChain

        public AppiumWebElement FindElementByIosClassChain(string selector) =>
            FindElement(MobileSelector.IosClassChain, selector);

        public ReadOnlyCollection<AppiumWebElement> FindElementsByIosClassChain(string selector) =>
            FindElements(MobileSelector.IosClassChain, selector);

        #endregion
    }
}