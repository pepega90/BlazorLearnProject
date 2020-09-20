using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServer.Pages
{
    /* Contoh base class approach code splitting component di brazor project
     * kita membuat class CounterBase Anda dapat memberi nama kelas apa pun yang Anda inginkan, tetapi konvensi umum memiliki nama yang sama sebagai komponen tetapi diakhiri dengan kata Base.
     * lalu kita harus melakukan inherit ke class ComponentBase yang ada di Microsoft.AspNetCore.Components namespace.
     */
    public class CounterBase : ComponentBase
    {
        // access modifier setidaknya harus protected jika Anda ingin mengakses anggota kelas dari HTML.
        protected int currentCount = 0;

        protected string fontFamily = "Verdana";

        protected void IncrementCount()
        {
            currentCount++;
        }
    }
}
