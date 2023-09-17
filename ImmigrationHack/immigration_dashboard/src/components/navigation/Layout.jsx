import {Navigate, BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import LoginController from '../login/LoginController';
import HomeController from '../home/HomeController';
import { useUser } from '../usercontext/UserContext';
import DocumentsController from '../documents/DocumentsController';
import FilesController from '../files/FilesController';
import SettingsController from '../settings/SettingsController';
import Header from './Header';


function Layout(props) {
    // App Component
    // Check if the token exists in localStorage on component mount
    const token = localStorage.getItem('token');
    const { userResult } = useUser(); 

    return (
        <Router>
            <div className="App">
                    <Header userResult={(userResult || token)} class="block" {...props} />
                    <Routes class="block">
                        {(userResult || token) ? ( // Check if user is authenticated
                            <>
                                <Route exact path="/home" element=<HomeController {...props} />></Route>
                                <Route exact path="/documents" element=<DocumentsController {...props} />></Route>
                                <Route exact path="/settings" element=<SettingsController {...props} />></Route>
                            </>
                        ) : (
                            <>
                            <Route exact path="/login" element=<LoginController {...props} />></Route>
                                    <Route exact path="/home" element=<LoginController {...props} />></Route>
                                </>
                        )}

                        {/* Redirect to a default route if none of the conditions match */}
                        <Route path="/" element={<Navigate to="/login" />} />
                    </Routes>
            </div>
        </Router>
    );
}

export default Layout;