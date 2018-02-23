using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace I4GUI
{
   public class Agents : ObservableCollection<Agent> { };  // Just to reference it from xaml

   [Serializable]
   public class Agent
   {
      string id;
      string codeName;
      string speciality;
      string assignment;

      public Agent()
      {
      }

      public Agent(string aId, string aName, string aAddress, string aSpeciality, string aAssignment)
      {
         id = aId;
         codeName = aName;
         speciality = aSpeciality;
         assignment = aAssignment;
      }

      public string ID
      {
         get
         {
            return id;
         }
         set
         {
            id = value;
         }
      }

      public string CodeName
      {
         get
         {
            return codeName;
         }
         set
         {
            codeName = value;
         }
      }

      public string Speciality
      {
         get
         {
            return speciality;
         }
         set
         {
            speciality = value;
         }
      }

      public string Assignment
      {
         get
         {
            return assignment;
         }
         set
         {
            assignment = value;
         }
      }
   }
}