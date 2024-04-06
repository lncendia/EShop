const TextBlock = ({text, className = ''}: { text: string, className?: string }) => {
    return (
        <div className={`text-center ${className}`.trim()}>
            <div className="my-1 fs-5">{text}</div>
        </div>
    );
};

export default TextBlock;