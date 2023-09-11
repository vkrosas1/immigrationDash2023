import { Link } from "react-router-dom";

function Header() {

    const headerStyle = {
        textAlign: 'center',
        background: '#333',
        color: "#fff"
    }

    const linkStyle = {
        color: '#fff',
        textDecoration: 'none'
    }

    return (
        <header style={headerStyle}>
            <h1 className="is-size-1">Immigration Dashboard</h1>
            <Link style={linkStyle} to="/home">Home</Link> | <Link style={linkStyle} to="/documents">Documents</Link> | <Link style={linkStyle} to="/files">Files</Link> | <Link style={linkStyle} to="/settings">Settings</Link>
        </header>
    );
}

export default Header;