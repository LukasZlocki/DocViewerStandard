using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocViewerStandard.Models
{
    class UserLanguage
    {
        private bool IsPolish = true;
        private bool IsUkraine = false;


        // Getters
        public bool isPolishLanguageOn()
        {
            if (IsPolish == true)
            {
                return true;
            }
            else return false;
        }


        // Setters
        public void SetToPolishLanguage()
        {
            this.IsPolish = true;
            this.IsUkraine = false;
        }

        public void SetToUkraine()
        {
            this.IsPolish = false;
            this.IsUkraine = true;
        }


    }
}
