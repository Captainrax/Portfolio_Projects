using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace WPF_XML_Testing
{
    [XmlRoot(ElementName = "student")]
    public class Student
    {
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "login")]
        public string Login { get; set; }
        [XmlElement(ElementName = "born")]
        public string Born { get; set; }

        [XmlAttribute(AttributeName = "studentid")]
        public string Studentid { get; set; }
        [XmlAttribute(AttributeName = "cid")]
        public string Cid { get; set; }

        private XMLClasses m_parent;
        public void setParent(XMLClasses p_parent)
        {
            m_parent = p_parent;
        }
    }
    [XmlRoot(ElementName = "students")]
    public class Students
    {
        [XmlElement(ElementName = "student")]
        public List<Student> Student { get; set; }
    }


    [XmlRoot(ElementName = "subject")]
    public class Subject
    {
        [XmlAttribute(AttributeName = "sid")]
        public string Sid { get; set; }
        [XmlAttribute(AttributeName = "cid")]
        public string Cid { get; set; }
        [XmlAttribute(AttributeName = "shorthand")]
        public string Shorthand { get; set; }
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "description")]
        public string Description { get; set; }
        [XmlElement(ElementName = "URL")]
        public string URL { get; set; }

        private XMLClasses m_parent;
        public void setParent(XMLClasses p_parent)
        {
            m_parent = p_parent;
        }
    }

    [XmlRoot(ElementName = "subjects")]
    public class Subjects
    {
        [XmlElement(ElementName = "subject")]
        public List<Subject> Subject { get; set; }
    }

    [XmlRoot(ElementName = "class")]
    public class Class
    {
        [XmlAttribute(AttributeName = "cid")]
        public string Cid { get; set; }
        [XmlAttribute(AttributeName = "rid")]
        public string Rid { get; set; }

        [XmlElement(ElementName = "name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "startdate")]
        public string StartDate { get; set; }
        [XmlElement(ElementName = "length")]
        public string Length { get; set; }
        [XmlElement(ElementName = "description")]
        public string Description { get; set; }


        private XMLClasses m_parent;
        public void setParent(XMLClasses p_parent)
        {
            m_parent = p_parent;
        }
    }

    [XmlRoot(ElementName = "Classes")]
    public class Classes
    {
        [XmlElement(ElementName = "class")]
        public List<Class> Class { get; set; }
    }

    [XmlRoot(ElementName = "room")]
    public class Room
    {
        [XmlAttribute(AttributeName = "rid")]
        public string Rid { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "building")]
        public string Building { get; set; }

        private XMLClasses m_parent;
        public void setParent(XMLClasses p_parent)
        {
            m_parent = p_parent;
        }
    }

    [XmlRoot(ElementName = "rooms")]
    public class Rooms
    {
        [XmlElement(ElementName = "room")]
        public List<Room> Room { get; set; }
    }

    [XmlRoot(ElementName = "TechCollege")]
    public class XMLClasses
    {
        [XmlElement(ElementName = "students")]
        public Students Students { get; set; }
        [XmlElement(ElementName = "subjects")]
        public Subjects Subjects { get; set; }
        [XmlElement(ElementName = "classes")]
        public Classes Classes { get; set; }
        [XmlElement(ElementName = "rooms")]
        public Rooms Rooms { get; set; }

        private static String m_path = "";

        public static XMLClasses XMLClassesFromXML(String path)
        {
            m_path = path;
            XmlSerializer serializer = new XmlSerializer(typeof(XMLClasses));
            StreamReader reader = new StreamReader(path);
            XMLClasses m_sys = (XMLClasses)serializer.Deserialize(reader);
            reader.Close();
            m_sys.setParents();
            return m_sys;
        }

        public void Save()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(XMLClasses));
            StreamWriter writer = new StreamWriter(m_path);
            serializer.Serialize(writer, this);
            writer.Close();
        }
        public void setParents()
        {
            foreach (Student m_child in Students.Student)
                m_child.setParent(this);
            foreach (Subject m_child in Subjects.Subject)
                m_child.setParent(this);
            foreach (Class m_child in Classes.Class)
                m_child.setParent(this);
            foreach (Room m_child in Rooms.Room)
                m_child.setParent(this);
        }
        public static XMLClasses XMLClassesFromXML2(String path)
        {
            //m_path = path;
            XmlSerializer serializer = new XmlSerializer(typeof(XMLClasses));
            StreamReader reader = new StreamReader(path);
            XMLClasses m_sys2 = (XMLClasses)serializer.Deserialize(reader);
            reader.Close();
            m_sys2.setParents2();
            return m_sys2;
        }
        public void setParents2()
        {
            foreach (Class m_child in Classes.Class)
                m_child.setParent(this);
        }
    }

}