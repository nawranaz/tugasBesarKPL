using System;
using System.Collections.Generic;
using System.Linq;
using TubesKPL_KitaBelajar.Library.Model;

namespace TubesKPL_KitaBelajar.Library.Services
{
    public static class ModulSearchService
    {
        public static List<ModulPembelajaran> CariModul(List<ModulPembelajaran> semuaModul, string keyword)
        {
            if (semuaModul == null || semuaModul.Count == 0 || string.IsNullOrWhiteSpace(keyword))
                return new List<ModulPembelajaran>();

            return semuaModul
                .Where(m =>
                    m != null && (
                        (!string.IsNullOrEmpty(m.Judul) && m.Judul.Contains(keyword, StringComparison.OrdinalIgnoreCase)) ||
                        (!string.IsNullOrEmpty(m.Konten) && m.Konten.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                    )
                )
                .ToList();
        }
    }
}
