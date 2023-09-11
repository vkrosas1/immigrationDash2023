import { useEffect, useState } from 'react';
import ReactModal from 'react-modal';
import DocumentView from './DocumentView';
import FileService from '../../api/FileService';
import DocumentsList from './DocumentsList';
import { sortStatuses } from '../../Utilities';
import { TEMP_USER } from '../../Constants';

function DocumentsController(props) {

    const [documentForms, setDocumentForms] = useState([]);
    const [selectedDocumentForm, setSelectedDocumentForm] = useState(null);
    const [isModalOpen, setIsModalOpen] = useState(false);
    const [isLoading, setIsLoading] = useState(true);
    const [isError, setIsError] = useState(false);

    useEffect(() => {
        async function getDocumentForms() {
            setIsError(false);
            setIsLoading(true);
            const result = await FileService.getUserDocumentForms(TEMP_USER.id);
            if (result.isSuccessful) {
                setDocumentForms(result.data.sort(sortStatuses))
            } else {
                setIsError(true);
            }
            setIsLoading(false);
        }
        getDocumentForms();
    }, [])

    const onDocumentSelect = (documentForm) => {
        setSelectedDocumentForm(documentForm)
        ReactModal.setAppElement('#root'); // Ensures screen readers can access modal content
        setIsModalOpen(true);
    }

    props = {
        ...props,
        selectedDocumentForm,
        setSelectedDocumentForm,
        setIsModalOpen,
        documentForms,
        setDocumentForms,
        onDocumentSelect
    }

    const style = {
        content: {
            width: '60%',
            'textAlign': 'center',
            'marginLeft': 'auto',
            'marginRight': 'auto'
        }
    }

    return (
        <div class="container pt-4">
            {
                isLoading ?
                    <div>
                        <progress class="progress is-small is-primary" max="100">15%</progress>
                    </div>
                    :
                    <div>
                        <DocumentsList {...props} />
                    </div>
            }
            {isError ? <h1>Request Failed</h1> : null}
            <ReactModal style={style} isOpen={isModalOpen}>
                <DocumentView {...props} />
            </ReactModal>
        </div>
    );
}

export default DocumentsController;