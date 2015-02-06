using System;
using System.Collections.Generic;
using System.Text;

namespace DeezerWin2dExperiments
{
    class AlbumDataSource : BaseViewModel
    {
        public Album CurrentAlbum { get; set; }

        public AlbumDataSource()
        {
            //InitKatyPerryAlbum();
            InitHooverphonicAlbum();
        }

        private void InitHooverphonicAlbum()
        {
            CurrentAlbum = new Album();
            CurrentAlbum.Title = "Reflection";
            CurrentAlbum.Fans = 7165;
            CurrentAlbum.ArtistName = "Hooverphonic";
            CurrentAlbum.ArtistImageUri = new Uri("http://cdn-images.deezer.com/images/artist/da11a21b644c23920d66b86dc8d36327/230x1800.jpg");
            CurrentAlbum.AlbumCoverUri = new Uri("http://cdn-images.deezer.com/images/cover/8bc4eacae5d504e73ce835258acb7d5a/500x500-000000-80-0-0.jpg");

            CurrentAlbum.Tracks.Add(new Song()
            {
                Position = 1,
                Title = "Amalfi",
                Duration = "03:17",
                WaveformData = "AFECCEDDCGDDDIHFEHECCEEDCFCDCGFEDGDCCDDCCGCDCFEEDGECCEDECFCCDFEEEYGCDDGKKiHEKNHFNjJDCLJNTiIMQSMNVpprqnpnowxrtwusrttqqprnpwxrttrsstwpporkjuwttprqqsvtsruonuutypqpvsfYZagllvqoqsmintiYcihgrwpssrmmrstqsqopqrtsvqurusttunpqsuutuopqsunlmmmolwoqrtkmntrkiikpnxupsronknXPOLLHGVVPNUXVRprmqipjknqqonnnsqpqqqtlpwwswrspqwrpttyrtxvsxprtutqptnnmpptrupmmsrspqlooonqosororvssuoqloqvtvrtssqrsuosrrtutrnmruqqltmpmppsruqpttpumsmpnqstqtnmqwiYOLHEDCGDCDCEDCCCBBBAAAAAAAAAAAAAAAAA"
            });

            CurrentAlbum.Tracks.Add(new Song()
            {
                Position = 2,
                Title = "ABC Of Apology",
                Duration = "03:01",
                WaveformData = "mwuosvvptttnuwwtuwusuxtrvvvnvsvttvuotvvnsxuqttstvuvptvtotssourrqtrtpsuvttttortsuuusotvrrrqsotprksrqlssspqquluxusuvtovurqsxtpwsvqptrmtusptuppuvttsusptttrstpkuorpqtrnstrrtqtpvqvstnuVunvYuqvpsvuvrsofrsqgovqkurrtwcwXviuSxpupuqwvqqpYqsqlpsomtqwsqtrlquorsttmtxtssvuqusqnrpqoytwpotqktutmpusousrrquupvtroqppkxowuunvYvjuXuquYspyXvpvUtpvftnxYrswwvivTtlwYrqvVwqxYwruVunvVvosYsuuwprqfpspjqtsosvvrrusjssrkoqqntptprrqirrrnpqrotwtustqmtsqpsspnvrsnsieZZWWTRQOMLFUXhfZXWUXWXUTRRPNKIHGFEDCCBBBAAAAAAAA"
            });

            CurrentAlbum.Tracks.Add(new Song()
            {
                Position = 3,
                Title = "Ether",
                Duration = "02:51",
                WaveformData = "JwprprqrtrhqjprptvkpkpqprwholqrtZpghepqqppWfikroqqfnklpoqqYkYkqpfnVXXonnYjQeXlkhmrckkmrsWmVgfnqqrtsqmutqsvssttxutuussqnruutxvwuuvrususwsssqquuuuvvvttswuupWgkYVYPqfojnpokqXiWgokprjlmopmrseZYrrmquknYiqlqsZiekokYnhpjiqmnrhmcrqqirooqrrtuttsuwuuwvvsvvrwvwvuwsvwyqoqtusrustwuwxuutssvwusvpYXfgYTRhSdUkdmrqRgRlomohQdZjmlplPYRinfujViZnomtqSgSillohSZSknjUqVTVSPSOrdjYorousWebgmoYqgmlnpoqsYilrTTSROKHFECEqorrursurtuuvusuvvsqpottvtvwvwwwyupsxystussvxxuwqxswrqovrUiaTRRQPOLKIHFFEDCCCBBAAAAAAAAAAAA"
            });

            CurrentAlbum.Tracks.Add(new Song()
            {
                Position = 4,
                Title = "Radio Silence",
                Duration = "03:06",
                WaveformData = "NIMHLHMJmmosmqnwnqnupooknpppoooqmrouoqomenlqcjYukphugmakgmjpWgXpjohvZkbliqcredZekgfnbkhnhoYieggceeYgYiWkdldoclkilnnkhnkmgjYpcmfgknnnklnUOSMoNRNkiqmrflbnmpkslojojoohknenlqmZlplpjmYubhhjhYYYcgjpjpXkYeecdhajYWYZdodqfnijmnnnmijglYiodnXhnomojjoWcllnhnYioplnjfcoggjmiYhkrxvyrJCBECBEKHFEGCCDKHFCDCCGKGHGIDCDIFDDDHFILMHLHKIJKMIMFKHLLMLPLPOLLKJMCBAAAAAFkporpmmpqsoqplimkklXghZXpoppkmmhdpmrkmgnqoolnmemilgkkklmssuupOCEDDDCEFFDCEEDCCCFGFFEEEDCBBAAAAAAAA"
            });

            CurrentAlbum.Tracks.Add(new Song()
            {
                Position = 5,
                Title = "Bad Weather",
                Duration = "02:22",
                WaveformData = "FFEIIGHKIMLIIFEIIGHIGFNHFIPobNJSNLPPthPrkQOMPKMPUUKGKQOJLMNTVYRZVRMJNMJTOhRMJROrsjWHENPLJOQYpdYIFHRNRNPOMKFJQMLUOIROProfHEDHTrnSOLONKSPpLkWTNMNONRVgRGEORPMMNONUZQrjRLJNNKVVqXOJTPksZfJEHPMINQXmiWOGIpPSQONNIFKPKTRNIQNSyjkQGDDEDDIEDLFEPLGPOLWPKKECCCCDDEGHFHGEIKHHOLNSNKIEDCCCLMJJOUprXXKFMUKINPYnjRJFTXNORPONGFLOJOTLJKIOnnYdSEDDCBCBBBBBBBBAAAAA"
            });

            CurrentAlbum.Tracks.Add(new Song()
            {
                Position = 6,
                Title = "Boomerang",
                Duration = "02:12",
                WaveformData = "ipiririsUoloirkqmqfolripTremgphqZpdqWmhoUqZkYnYogfiomhjmsmjqmOvwvZhlmgippmZqiPvxvsYqipfqTphpgoerXqjoXqipVqgnWoepjhhkhjhnrmhniOwyvmfjofcpolhojNttwnlpolnrnqsvplosmololmoqlpksnporjoqsiqoqmlSURIECBGDCBIECCJvvwgfmniZkpiolrfhZokeimikjlcfiofionmXRQKGFECBAAAAAAAA"
            });

            CurrentAlbum.Tracks.Add(new Song()
            {
                Position = 7,
                Title = "Devil Kind of Girl",
                Duration = "02:40",
                WaveformData = "GKILwlpnupustqplskYPuipmtpxrtnrnulyrtlopvpoqpplktmstiXPemTSloiqlvputdWLZfYTfrhppooWovjqktpsspmojsncStapjomtqqmqkriwrtnpnoqrppnpjthVUiVPYlVRkqZqmrnrshTOYjXglpgrnonUOokdWqoYlsplSsnUptZZYqnlrsmcXmnVnomeTqpYlqZkUmmVmkocgqkiqrjsvqMEIqjupuqtqtnvnxnYSmZpnpjrpsjofqfvnoglkmdtopYqoqdQQdROVlXUoqfokvqunhSQchWfiomtmolXPpojYppXooliVlnfspjYirrrortjVspVkpllZqoXpsekUqnXpqohWmqloskopsNKMshuqrqsopionrquromsqvssqqhtqrjULIFCBBAAAAAAAAAAAA"
            });

            CurrentAlbum.Tracks.Add(new Song()
            {
                Position = 8,
                Title = "Single Malt",
                Duration = "02:27",
                WaveformData = "GGGFFFFEEFGFDEFIkmjXVQMNkmgXUOMOniYPokUQonjRjkTPOKMOlhZQomaPmngXhiXVTRQJXYVViZbdijhepmgReWVSpoqkjggYlijfZhVTTOMOwkvnvnslwrviujyrwotmwlxowounvowlthwosnvXuquZqftjrmxYpmxgtmuVprwqtprquvvvvluksmwnvlurrlursdtqvnxosluipjvgkZseputtvmsermtfrmvfpltiqititntfqisdrnsckVQPMIFECBAAAAAAAA"
            });

            CurrentAlbum.Tracks.Add(new Song()
            {
                Position = 9,
                Title = "Plasticine",
                Duration = "03:06",
                WaveformData = "BACCBABdyXtUwQplsTrXwZufxRqVuUnmtQlSrZtfpliotpppqsmppommsplnmmrqngnpnonqqjpnilmnpliqjolmqotujkkplntsomqmmlnqifiilnlmqYoqmggklSolpgZbZVSOvYoVuYkVtSsYudrjuQsTtSmXuUmTsTrkpnYmspmptslsqprqqpoopkotnntokplpplsrmoknnmlsipmmnkrshZopillqolrlpoprZYlookmmngmilipjlUqjnUjqlgPXnYjnsphhtShmhhTXrShjllhVijefjefhjmdmpiejrnnhpijmrmmfVUNMECCCECCCBCCDCDCCBBBDjlqpiopsjoppnnqmjdglommiogonkYqjlgpnnjrkfbefhijoWZnnphXXUOHDBBBBBBAAAAAAAAAAAAA"
            });

            CurrentAlbum.Tracks.Add(new Song()
            {
                Position = 10,
                Title = "Gravity",
                Duration = "03:06",
                WaveformData = "EBCCBCCCHCECFEGDDBBCBCCBFCDCEDEDGCFCFDGDFFGFEEFEgYXVVWYVfUUTUUdWZWXWVTRQbYXSQNOKdWJYVWLYglnnqqrvqZSnsYTqqUSprWmfrYSklUSlsUSrrWqYmWTorXSokposoYXYseKsrYLYtXJqsYktpYIrrfGVqVHoqbMVpULqrYbXmfJpshQiqVInsfdXpTHoqXZWoVKmqXJUpYIrneIusVQpkVSXqoqstqsyrYRlpZTjqUSosXmfpYSjmVVprWSruZoXoUTpqUSnqmssqqvslTjmqeepoTblpYgnrUgqoThpprqtsvvxpXTopYUjqXUqsXmhpYRmpWTopVTqteqYreUqpUSoinuqjWWVpXIpnUKYsXMqqWidpgKqoVKoqUKqrZZppWUVQPNJIHFEEDCCCBBBBAAAAAAAA"
            });

            //CurrentAlbum.Tracks.Add(new Song()
            //{
            //    Position = 11,
            //    Title = "Wait For A While",
            //    Duration = "02:43",
            //    WaveformData = "FBBBBBFBBBCDkYBYBjhYBWBXmYJVBXoVCWBXiYBWCYlYCWBdmXHWBVtsrpputrvsxttvuwrtvrssuvvqwntssputvwvrsuutsfYXXXrcWXXXuXhXZfsZXZYYsXZXYYrWXbYdwagYYWssussrvqqtuuvrswusspvuwxvswsoqslsuuuurstuutrorrspssostqponrrsutqstqpmsprrspswGIBBCCDHBCBBBIBFEBBuwwyvuwwwvuvyuwwuqvtwvvvutrqjopnvswtqqsunosrssxvrpwtqsporqvtqquvrtsgZcajwaYZeduYYWWgtWXrtnsYVUTVtTSmmjpPPOOOoMMLKRplXWTRPOMLKJIHGFEDCBAAAAAA"
            //});

            CurrentAlbum.Tracks.Add(new Song()
            {
                Position = 12,
                Title = "Roadblock",
                Duration = "02:30",
                WaveformData = "rpwvpcxwrmwvnhomrovsrlwvqmvvqorormvtqmwvtqwxqlpooplqnqsotnsrsonqooqrqnrqstuusjgfndtjrktqrjthhhsrsjtionurqkupsjherlytqmvxrowwslsoqhwusfwusmvwpqqptlwvmouvtpxyqomnqonnqqqpopqqtqspoqqqqqqqqsvwsjggontetotosppjlXuspkrnohssrntoqgcYsqronplsqrqomqolvrrsstsmsustsfddssuoqnttuovuoSEEqlscrZtmpkrkkhrqrkplnkursltnpeUOIDBBABBAAAAAAAAA"
            });


            CurrentAlbum.Tracks.Add(new Song()
            {
                Position = 13,
                Title = "Copper (CU)",
                Duration = "02:48",
                WaveformData = "plnZsmqnopljumrrqjqgsnqoymuoshrtsNqjtRqrsUuksUrwsTqmrPtvqZnqpfopsMqjpTpltQqnpRqmrSrirUqqoPnfuVmuukvjrXwlurnpvqnuppvkrqrorbwrsjcXtlpTkQmlsotRoTnktRrhtWrmpUrkrVqstWrirapmqkiVqllluivgqmtZwsrqupmrunvksXqjsYsrrkghggYhgYbkgejlkKkPeeWgdifkgfchliusttxmtkuirpoksnnqphrgrYrjpWtpsgggYTNJGECBAAAAAA"
            });

            CurrentAlbum.Tracks.Add(new Song()
            {
                Position = 14,
                Title = "Erased",
                Duration = "02:07",
                WaveformData = "ETPKIPWRLKNMIFJRVOKQPNJGLSPLJKLHFJPULJWSNJJPTOJVjePFMROJGOTPJMNRMJPKIFIOSMJNSRMHPURLNVkhZhQQLIOMMHKKQJHrvspjPSMIRNLIJLMKGUttmhUJIHGNTMIOTRNMRIFELSSLMnRLILPTNJNijIGOSPKJQTPJNQTOLLMIGLPSLINQOJJOTNKNXVPHQTQKLPPKHKOMJOrtomSSTOJRNLHKNQJPbsodXQMLJKLJGKLNIFRknXRfsnlkNLIIOLHFGuyqhUVWOPRRMGPOOIKPXPJNOOMLNNJGNMLIHMRMHNLJIGFIKGEDCCCCCBBBBBBBBBBBBAAAAAAAAAAAAA"
            });

            RaisePropertyChanged("CurrentAlbum");

        }

        private void InitKatyPerryAlbum()
        {
            CurrentAlbum = new Album();
            CurrentAlbum.Title = "P.R.I.S.M";
            CurrentAlbum.Fans = 312153;
            CurrentAlbum.ArtistName = "Katy Perry";
            CurrentAlbum.ArtistImageUri = new Uri("http://cdn-images.deezer.com/images/artist/57b4fff9f0084f427ceaf244ca582c49/230x1800.jpg");

            CurrentAlbum.Tracks.Add(new Song()
            {
                Position = 1,
                Title = "",
                Duration = TimeSpan.FromSeconds(224).ToString(""),
                WaveformData = ""
            });
        }
    }
}
