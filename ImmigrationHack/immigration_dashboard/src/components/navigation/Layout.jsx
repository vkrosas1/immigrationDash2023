import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import LoginController from '../login/LoginController';
import HomeController from '../home/HomeController';
import DocumentsController from '../documents/DocumentsController';
import FilesController from '../files/FilesController';
import SettingsController from '../settings/SettingsController';
import Header from './Header';
import UserService from "../../api/UserService";


function requireAuth(replace) {
    const userData = UserService.authenticateUser("test@me.com", "test");
    if (!userData) {
        replace({
            pathname: "/login",
            
        });
    }
    console.log("went in here"); 
}
function Layout(props) {

    return (
        <Router>
            <div className="App">
                <div className="container">
                    <Header class="block" {...props} />
                    <Routes class="block">
                        <Route exact path="/login" element=<LoginController {...props} />></Route>
                        <Route exact path="/home" element=<HomeController {...props} onEnter={requireAuth} />></Route>
                        <Route exact path="/documents" element=<DocumentsController {...props} onEnter={requireAuth} />></Route>
                        <Route exact path="/files" element=<FilesController {...props} onEnter={requireAuth} />></Route>
                        <Route exact path="/settings" element=<SettingsController {...props} onEnter={requireAuth} />></Route>
                        <Route to="/home" />
                    </Routes>
                </div>
            </div>
        </Router>
    );
}

export default Layout;