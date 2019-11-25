using System.Collections.Generic;

namespace EversignWebApp.Models
{
    public class File
    {
        public string name { get; set; }
        public string file_id { get; set; }
        public int pages { get; set; }
    }

    public class Signer
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string role { get; set; }
        public int order { get; set; }
        public string pin { get; set; }
        public string message { get; set; }
        public int signed { get; set; }
        public string signed_timestamp { get; set; }
        public int required { get; set; }
        public int deliver_email { get; set; }
        public string language { get; set; }
        public int declined { get; set; }
        public int removed { get; set; }
        public int bounced { get; set; }
        public int sent { get; set; }
        public int viewed { get; set; }
        public string embedded_signing_url { get; set; }
        public string status { get; set; }
    }

    public class Recipient
    {
        public string name { get; set; }
        public string email { get; set; }
        public string role { get; set; }
        public string message { get; set; }
        public int required { get; set; }
        public string language { get; set; }
    }

    public class Log
    {
        public string @event { get; set; }
        public string signer { get; set; }
        public int timestamp { get; set; }
    }

    public class EversignDocument
    {
        public string document_hash { get; set; }
        public string requester_email { get; set; }
        public string custom_requester_name { get; set; }
        public string custom_requester_email { get; set; }
        public int is_draft { get; set; }
        public int is_template { get; set; }
        public int is_completed { get; set; }
        public int is_archived { get; set; }
        public int is_deleted { get; set; }
        public int is_trashed { get; set; }
        public int is_cancelled { get; set; }
        public int is_expired { get; set; }
        public int embedded { get; set; }
        public int in_person { get; set; }
        public int embedded_signing_enabled { get; set; }
        public int flexible_signing { get; set; }
        public string permission { get; set; }
        public string template_id { get; set; }
        public string title { get; set; }
        public string subject { get; set; }
        public string message { get; set; }
        public int use_signer_order { get; set; }
        public int reminders { get; set; }
        public int require_all_signers { get; set; }
        public string redirect { get; set; }
        public string redirect_decline { get; set; }
        public string client { get; set; }
        public int created { get; set; }
        public int expires { get; set; }
        public List<File> files { get; set; }
        public List<Signer> signers { get; set; }
        public List<Recipient> recipients { get; set; }
        public List<List<object>> fields { get; set; }
        public List<Log> log { get; set; }
        public List<object> meta { get; set; }
    }
}