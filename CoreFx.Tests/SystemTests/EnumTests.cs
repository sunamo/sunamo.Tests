using sunamo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace CoreFx.Tests.SystemTests
{
    

    //enum EnumB
    //{
    //    BA,
    //    BB
    //}

    public class EnumTests
    {
        [Fact]
        public void CombinedEnum()
        {
            EnumA enumA = EnumA.a | EnumA.b;
            Assert.Equal(true,  enumA.HasFlag(EnumA.a));
            Assert.Equal(false, enumA.HasFlag(EnumA.c));
        }

        [Fact]
        public void PassMoreEnumValueTest()
        {
            EnumA enumA = EnumA.a | EnumA.b;
            List<string> expected = TestData.listAB1;
            List<string> actual = GetEnum(EnumA.All);
            Assert.Equal(expected, actual);

            expected = new List<string>();
            actual = GetEnum(EnumA.None);
            Assert.Equal(expected, actual);

            expected = TestData.listA;
            actual = GetEnum(EnumA.a);
            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// If A2, all must be As Second
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumA"></param>
        /// <param name="haveAll"></param>
        /// <returns></returns>
        public List<string> GetEnum<T>(T enumA, bool haveAll = true) where T : struct, System.Enum
        {
            List<string> actual = new List<string>();

            int intVal = Convert.ToInt32(enumA);
            if (intVal == 0)
            {
                return actual;
            }
            else
            {
                // this in only way, no 
                if (intVal == 1)
                {
                    // Return already without none
                    var enumValues = EnumHelper.GetValues<T>(enumA.GetType());
                    for (int i = 1; i < enumValues.Count; i++)
                    {
                        actual.Add(enumValues[i].ToString());
                    }
                }
                else
                {
                    actual.Add(enumA.ToString());
                }
            }

            return actual;
        }




    }
}
