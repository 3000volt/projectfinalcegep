﻿using System;
using System.Collections.Generic;

namespace testactualisation.Appdata
{
    public partial class CoursCompetences
    {
        public int NbHcoursCompetence { get; set; }
        public string NoCours { get; set; }
        public string CodeCompetence { get; set; }
        public bool Complete { get; set; }

        public Competences CodeCompetenceNavigation { get; set; }
        public Cours NoCoursNavigation { get; set; }
    }
}
