namespace EliteAPI.Discord
{
    /// <summary>
    /// Class used to update the Rich Presence with.
    /// </summary>
    public class RichPresence
    {
        /// <summary>
        /// Empty constructor for a rich presence.
        /// </summary>
        public RichPresence() 
        {
            Icon = "ed";
        }

        /// <summary>
        /// Basic constructor for a rich presence.
        /// </summary>
        /// <param name="text">The first line of text.</param>
        public RichPresence(string line1)
        {
            Text = line1;
            Icon = "ed";
        }

        /// <summary>
        /// Basic constructor for a rich presence.
        /// </summary>
        /// <param name="text">The first line of text.</param>
        /// <param name="textTwo">The second line of text.</param>
        public RichPresence(string line1, string line2)
        {
            Text = line1;
            TextTwo = line2;
            Icon = "ed";
        }

        /// <summary>
        /// The first line of text.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// The second line of text.
        /// </summary>
        public string TextTwo { get; set; }

        /// <summary>
        /// The main icon ID.
        /// </summary>
        public string Icon { get; set; }
        
        /// <summary>
        /// The text that should be displayed when hovering over the main icon.
        /// </summary>
        public string IconText { get; set; }

        /// <summary>
        /// The secondary icon ID.
        /// </summary>
        public string IconTwo { get; set; }

        /// <summary>
        /// The text that should be displayed when hovering over the secondary icon.
        /// </summary>
        public string IconTextTwo { get; set; }
    }
}
