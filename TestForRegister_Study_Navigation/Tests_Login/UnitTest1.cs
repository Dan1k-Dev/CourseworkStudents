using NUnit.Framework;
using Study_Navigation;
using Study_Navigation.Classes_Tests;

namespace TestForRegister_Study_Navigation
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        { }

        /// <summary>
        /// ������������� Unit ���� ��� �������� ������ � ������ ����������� - 1
        /// </summary>
        [Test]
        public void TestForLogin_True()
        {
            Class_Test_Log testLogTrue = new Class_Test_Log();
            Assert.AreEqual(true, testLogTrue.LogIsTrue("admin", "admin", 1));
        }

        /// <summary>
        /// ������������� Unit ���� ��� �������� ������ � ������ ��� ����������� - 2 
        /// </summary>
        [Test]
        public void TestForLoginFalse()
        {
            Class_Test_Log testLogTrue = new Class_Test_Log();
            Assert.AreEqual(false, testLogTrue.LogIsFalse("admin", "admin", 1));
        }

        /// <summary>
        /// ������������� Unit ���� ��� �������� ������ � ������ ��� ������������ - 3 
        /// </summary>
        [Test]
        public void TestForRegTrue()
        {  
            Class_Test_Reg testRegTrue = new Class_Test_Reg();
            Assert.AreEqual(true, testRegTrue.RegIsTrue("������� �.�", "�����1", "admin"));
        }

        /// <summary>
        /// ������������� Unit ���� ��� �������� ������ � ������ ��� ����������� - 4
        /// </summary>
        [Test]
        public void TestForRegFalse()
        {
            Class_Test_Reg testRegTrue = new Class_Test_Reg();
            Assert.AreEqual(false, testRegTrue.RegIsFalse("������� �.�", "�����1", "admin"));
        }

        /// <summary>
        /// �������������� ���� ��� �������� - 5 
        /// </summary>
        [Test]
        public void TestDiscipline()
        {
            Class_Test_Discipline addDisc = new Class_Test_Discipline();
            Assert.AreEqual(true, addDisc.NewDiscipline(title: "�������", teacher: 1, hours: 43));
        }

        /// <summary>
        /// �������������� ���� ��� �������� - 6
        /// </summary>
        [Test]
        public void TestForStud()
        {
            Class_Test_Stud addStud = new Class_Test_Stud();
            Assert.AreEqual(true, addStud.NewStud(FCs: "������� �.�.", numb_grade: 245788, date_born: "16.03.2005", address: "������, 6-15", telephone: "8(890) 555-35-35", group: 11, fluorgr: "������������"));
        }

        /// <summary>
        /// �������������� ���� ��� �������� - 7
        /// </summary>
        [Test]
        public void TestForAttend()
        {
            Class_Test_Attend addAttend = new Class_Test_Attend();
            Assert.AreEqual(false, addAttend.NewAttend(student: 1, date: "24.05.2021", quantity_gr: 4, quantity_nGR: 0, general_hours: 4));
        }

        /// <summary>
        ///  �������������� ���� ��� �������� - 8
        /// </summary>
        [Test]
        public void TestForPerf()
        {
            Class_Test_Perf test_Perf = new Class_Test_Perf();
            Assert.AreEqual(true, test_Perf.NewPerf(student: 4, discipline: 3, estim: 5));
        }

        /// <summary>
        ///  �������������� ���� ��� �������� - 9
        /// </summary>
        [Test]
        public void TestForGroup()
        {
            Class_Test_Group aadGroup = new Class_Test_Group();
            Assert.AreEqual(true, aadGroup.NewGroup(title: "18��-2", year: "2018", elder: "���������� �.�.", director: 3, edPr: 9));
        }

        /// <summary>
        ///  �������������� ���� ��� �������� - 10
        /// </summary>
        [Test]
        public void TestForSpec()
        {
            Class_Test_Spec addSpec = new Class_Test_Spec();
            Assert.AreEqual(true, addSpec.NewSpec(title: "���������"));
        }

        /// <summary>
        ///  �������������� ���� ��� �������� - 11
        /// </summary>
        [Test]
        public void TestForFac()
        {
            Class_Test_Fac addFac = new Class_Test_Fac();
            Assert.AreEqual(true, addFac.NewFac(title: "������������� ����", headDep: "������� �.�.", formEd: 2, Spec: 14));
        }
    }
}