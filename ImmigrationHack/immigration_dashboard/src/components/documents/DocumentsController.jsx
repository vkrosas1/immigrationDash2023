import { useState, useEffect } from "react";
import FileService from "../../api/FileService";
import { STATUSES, TEMP_USER, getCountry } from "../../Contstants";
import DocDropdown from "./DocDropdown";
import PathService from "../../api/PathService";
import UserService from "../../api/UserService";
import { useNavigate } from 'react-router-dom';

function DocumentView(props) {

    const [errorMessages, setErrorMessages] = useState({});
    const [isSubmitted, setIsSubmitted] = useState(false);
    const [expirDate, setExpirDate] = useState('');
    const [issueDate, setIssueDate] = useState('');
    const [issueCoun, setIssueCoun] = useState("");
    const [docType, setDocType] = useState("");
    const [allDocs, setAllDocs] = useState([]);
    const navigate = useNavigate();

    const handleSubmit = async (event) => {
        event.preventDefault();

        if (docType && issueCoun) {
            const email = localStorage.getItem('email');
            const user = await UserService.getUserInfo(email).then((result) => {
                return result;
            });

            const docInfo = await FileService.getDocumentTypeByName(docType.label).then((result) => {
                return result;
            }); // testing only
            if (docInfo) {
                await FileService.uploadDocument(expirDate, issueDate, issueCoun, docInfo.data.id, docInfo.data, user.data.id).then((result) => {
                    result.isSuccessful ? setIsSubmitted(true) : setErrorMessages({ name: "submit", message: errors.submit });
                });
            }
        } else {
            if (!docType) {
                setErrorMessages({ name: "dropdown", message: errors.dropdown });
            }
            if (!issueCoun) {
                setErrorMessages({ name: "country", message: errors.country });
            }
        }
    };

    useEffect(() => {
        const getAllDocs = async () => {
            const getUserInfo = await UserService.getUserInfo(localStorage.getItem('email'));
            const paths = await PathService.getAllUserDocs(getUserInfo.data.id);
            setAllDocs(paths.data);

            return "You haven't added any documents yet";
        }; getAllDocs();
    }, []);

    const documentOptions = [
        { value: "birth certificate", label: "Birth Certificate" },
        { value: "Green Card", label: "Green Card" },
        { value: "H4B", label: "H4B" },
        { value: "H1B", label: "H1B" },
        { value: "opt", label: "OPT" },
        { value: "ged", label: "GED" }
    ];

    var curr = new Date();
    curr.setDate(curr.getDate() + 3);
    var date = curr.toISOString().substring(0, 10);

    // set the value to the props
    // props.setIssueDate(issueDate);

    const getDocumentType = (value) => {
        setDocType(value); // save documentTypeChosen to the state of docType 
    }

    // Generate JSX code for error message
    function renderErrorMessage(name) {
        return name === errorMessages.name && (
            <div className="error">{errorMessages.message}</div>
        );
    }

    const errors = {
        dropdown: "Please select document name.",
        country: "Please select country",
        submit: "Failed to submit document"
    };
  
    // write a form that will take in the document type, issue date, expiration date, country issued, and comments and save it to the database
    const renderForm = (
        <div className="App">
            <form className={allDocs ? "documentsUpload" : "documentsUpload firstTime"} onSubmit={handleSubmit}>
                <ul><li>
                    <div>
                        <DocDropdown
                            isSearchable
                            isMulti
                            placeHolder="Select document type"
                            options={documentOptions}
                            value={docType}
                            onChange={(value) => console.log("here is onChange in DocController: " + value)}
                            sendToParent={getDocumentType}
                            required
                        />
                        {renderErrorMessage("dropdown")}
                    </div>
                </li>
                    <li>
                        <label for="issueDate" required>Issued date:</label>
                        <input id="dateRequired" type="date" name="dateRequired" defaultValue={date} value={issueDate} onChange={(e) => setIssueDate(e.target.value)} required />
                    </li>
                    <li>
                        <label for="expirationDate">Expiration date:</label>
                        <input id="dateRequired" type="date" name="dateRequired" defaultValue={date} value={expirDate} onChange={(e) => setExpirDate(e.target.value)} required />
                    </li>
                    <li>
                        <div className="divLabel">Country issued:</div>
                        <div className="countryOrigin" value={issueCoun} onChange={(e) => setIssueCoun(e.target.value)} required={true}>{getCountry()}
                            {renderErrorMessage("country")}
                        </div>
                    </li>
                    <div>
                        <button>Submit</button>
                        {renderErrorMessage("submit")}
                    </div>
                </ul>
            </form>
            <div className="submittedDocsSection">Submitted Documents
                <div className="submittedDocs">{allDocs && allDocs.map((doc) => <li>{doc.documentTypeName}, Expiration Date: { doc.userDocument.expirationDate.substring(0, 10)}</li>)} </div>
            </div>
        </div>
    );

    const submitMore = (
        <div className="App">
            <div>
                <button onClick={() => setIsSubmitted(false)}>Submit another document?</button>
                <button onClick={() => navigate('/home')}>See paths!</button>
            </div>
        </div>
    );

    return (
        <div className="documents">
            <div className="documentUpload-form">
                {isSubmitted ? submitMore : renderForm}
            </div>
        </div>
    );
}

export default DocumentView;