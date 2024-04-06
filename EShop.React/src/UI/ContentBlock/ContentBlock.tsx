import React from 'react';
import styles from "./ContentBlock.module.css"

const ContentBlock = ({className = '', children}: { className?: string, children: React.ReactNode }) => {
    return (
        <div className={`${className} ${styles.content} shadow`}>
            {children}
        </div>
    );
};

export default ContentBlock;