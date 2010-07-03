<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	The SimpleStore Product
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>The SimpleStore Product</h2>

    <h3>Requirements</h3>

    <ul>
        <li><b>Requirements</b><br />
            Requirements were defined for the SimpleStore project by outlining the desired functionality the site would support,
            describing the topic domain, and sketching up a use case diagram. From the use case diagram, use case details 
            documents were created to fill out each scenario.
            <br />
            <img height="30" width="30" src="../../Content/word-icon.gif" border="1" alt="Word document" /> <a href="../../Content/Docs/Requirements.docx">Requirements</a>
        </li>
        <li><b>Wireframes</b><br />
            UI wireframes are a critical part of refining the requirements. This move the design from "User needs to add a product" to
            the actual actions and data necessary to complete the process.
            <br />
            <img height="30" width="30" src="../../Content/visio_icon.gif" border="1" alt="Visio document" /> <a href="../../Content/Docs/Wireframes.vsd">Public Site Wireframes</a><br />
            <img height="30" width="30" src="../../Content/visio_icon.gif" border="1" alt="Visio document" /> <a href="../../Content/Docs/AdminToolWireframes.vsd">Admin Tool Wireframes</a>
        </li>
    </ul>

    <h3>Architecture</h3>

    <ul>
        <li><b>Network architecture</b><br />
            Being such a small site, SimpleStore's network topology requirements are very low. Thanks to the vagaries of the 
            Internet, however, sites must be able to scale quickly to meet unexpected demand. Should a hosted store become
            very popular, it risks dragging down other stores on the same server. After examining some hosting providers,
            Amazon Web Services was selected for its great feature set. In fact, this site right now is running on a virtual
            server at Amazon as part of our proof of concept!
            <br />
            <img height="30" width="30" src="../../Content/word-icon.gif" border="1" alt="Word document" /> <a href="../../Content/Docs/NetworkArchitecture.docx">Network Architecture</a>
        </li>
        <li><b>Database schema</b><br />
            A good db schema is a critical part of any dynamic site. The SimpleStore requirements are not very complicated,
            but designing a flexible, normalized backend goes a long way in making the site easy to extend and work on in the future
            <br />
            <img height="30" width="30" src="../../Content/word-icon.gif" border="1" alt="Word document" /> <a href="../../Content/Docs/DatabaseSchema.docx">Database Schema</a>
        </li>
        <li><b>Website software architecture</b><br />
            The actual design of the web architecture was the focus of the SimpleStore research project. We opted to develop on
            a Microsoft technology stack, and chose their MVC web architecture as our starting point. From there we highlighted
            the <i>Single Responsibility Principle</i>, <i>Unit Testing</i>, and <i>Convention over Configuration</i> as our three
            major design goals, and analyzed reference architectures against those.
            <br />
            <img height="30" width="30" src="../../Content/word-icon.gif" border="1" alt="Word document" /> <a href="../../Content/Docs/Brossard_CapstoneResearchPaper.docx">Research Paper</a>
        </li>
    </ul>

    <h3>Source Code</h3>

    <p>
        What is a CS project without some actual code? The code for the architecture, the site, the database, and all the supporting 
        documents is <a href="http://github.com/fudder/cs493" target="_blank">in an online source repository</a> at GitHub. Here is 
        a brief to the contents:
        <ul>
            <li><code>/db</code> - This contains the database schema scripts, as well as a full MS SQL Server 2008 backup.</li>
            <li><code>/docs</code> - All the format documents created for eventual delivery as part of the project.</li>
            <li><code>/install</code> - These are the installation executables for some of the third party packages I used.</li>
            <li><code>/samples</code> - The sample application architectures I looked into.</li>
            <li><code>/src</code> - The actual source code used to create this site and all the prototypes.<br />
                <code>/src/site/builds/current</code> - Not actually source code, this is the compiled build published to this site.<br />
                <code>/src/site/SimpleStore</code> - The source code. SimpleStore.sln is a Visual Studio 2010 solution file if you have that.
            </li>
        </ul>
    </p>

</asp:Content>
